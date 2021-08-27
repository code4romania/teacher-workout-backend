namespace TeacherWorkout.Domain.Models
{
    public class Duration
    {
        private const int SecondsInMinute = 60;

        public int TotalSeconds { get; set; }
        
        public int Value { get; set; }
        
        public DurationUnit Unit { get; set; }

        public string DisplayValue => $"{Value} {Unit}";

        public static Duration FromSeconds(int seconds)
        {
            return new()
            {
                Value = seconds / SecondsInMinute,
                Unit = DurationUnit.Minutes,
                TotalSeconds = seconds
            };
        }
    }
}