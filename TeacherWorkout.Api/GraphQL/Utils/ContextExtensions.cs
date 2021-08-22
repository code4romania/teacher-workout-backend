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
        public static TInput ToInput<TInput>(this IResolveConnectionContext context)
            where TInput : PaginationFilter, new()
        {
            var result = new TInput
            {
                Before = CursorUtils.Deserialize(context.Before),
                After = CursorUtils.Deserialize(context.After),
                First = context.First,
                Last = context.Last
            };

            var knownProperties = new List<string> { "Before", "After", "First", "Last" };

            typeof(TInput).GetProperties()
                .Where(p => !knownProperties.Contains(p.Name))
                .ToList()
                .ForEach(p =>
                {
                    var value = context.GetArgument(p.PropertyType, p.Name);
                    p.SetValue(result, value);
                });
            
            return result;
        }
    }
}