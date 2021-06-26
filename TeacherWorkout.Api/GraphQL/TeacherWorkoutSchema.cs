using System;
using System.Linq;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutSchema : Schema
    {
        public TeacherWorkoutSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<TeacherWorkoutQuery>();
            Mutation = provider.GetRequiredService<TeacherWorkoutMutation>();
            AddTypeMappings();
            
            RegisterTypeMapping(typeof(ILessonStep), typeof(LessonStepInterface));
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
                        RegisterType(graphType);
                        RegisterTypeMapping(clrType, graphType);
                    }
                });
        }
    }
}