namespace TeacherWorkout.Domain.Common
{
    public class PaginationFilter
    {
        public int? First { get; set; }
        public int? After { get; set; }

        public int? Last { get; set; }
        public int? Before { get; set; }
    }
}