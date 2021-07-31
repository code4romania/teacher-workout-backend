namespace TeacherWorkout.Domain.Models.Inputs
{
    public class PaginationInput
    {
        public int? First { get; set; }
        public int? After { get; set; }

        public int? Last { get; set; }
        public int? Before { get; set; }
    }
}