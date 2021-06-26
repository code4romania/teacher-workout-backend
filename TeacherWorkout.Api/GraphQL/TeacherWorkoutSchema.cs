using System;
using System.Linq;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutSchema : Schema
    {
        public TeacherWorkoutSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<TeacherWorkoutQuery>();
            AddTypeMappings();
        }

        private void AddTypeMappings()
        {
            var classTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass || t.IsEnum)
                .ToList();

            classTypes.Where(t => t.Namespace == "TeacherWorkout.Api.Models")
                .ToList()
                .ForEach(clrType =>
                {
                    var graphType = classTypes.Find(ct => ct.Name == $"{clrType.Name}Type") ??
                                    classTypes.Find(ct => ct.Name == $"{clrType.Name}Enum");
                    
                    if (graphType != null)
                    {
                        RegisterTypeMapping(clrType, graphType);
                    }
                });
        }
    }
}