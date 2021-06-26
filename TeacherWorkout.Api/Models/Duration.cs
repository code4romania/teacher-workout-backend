namespace TeacherWorkout.Api.Models
{
    public class Duration
    {
        public int Value { get; set; }
        
        public DurationUnit Unit { get; set; }

        public string DisplayValue => $"{Value} {Unit}";
    }
}