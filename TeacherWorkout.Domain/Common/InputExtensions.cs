using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Common
{
    public static class InputExtensions
    {
        public static PaginationFilter ToPaginationFilter(this PaginationInput input)
        {
            return new PaginationFilter
            {
                After = input.After,
                Before = input.Before,
                First = input.First,
                Last = input.Last
            };
        }
    }
}