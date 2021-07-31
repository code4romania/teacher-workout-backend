using GraphQL.Builders;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Utils
{
    public static class ContextExtensions
    {
        public static TInput ToInput<TInput>(this IResolveConnectionContext context)
            where TInput : PaginationInput, new()
        {
            var result = new TInput
            {
                Before = CursorUtils.Deserialize(context.Before),
                After = CursorUtils.Deserialize(context.After),
                First = context.First,
                Last = context.Last
            };

            // Todo: Parse other parameters
            
            return result;
        }
    }
}