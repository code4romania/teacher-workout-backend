using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Builders;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Utils
{
    public static class ContextExtensions
    {
        public static TInput ToInput<TInput>(this IResolveFieldContext context)
            where TInput : new()
        {
            var result = new TInput();

            ExtractProperties(context, result);
            
            return result;
        }

        private static void ExtractProperties<TInput>(IResolveFieldContext context, TInput result) where TInput : new()
        {
            typeof(TInput).GetProperties()
                .ToList()
                .ForEach(p =>
                {
                    var value = context.GetArgument(p.PropertyType, p.Name);
                    p.SetValue(result, value);
                });
        }
    }
}