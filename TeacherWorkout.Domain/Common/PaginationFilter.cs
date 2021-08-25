namespace TeacherWorkout.Domain.Common
{
    public class PaginationFilter
    {
        public int? First { get; set; }
        public string After { get; set; }

        public int? Last { get; set; }
        public string Before { get; set; }
    }
}