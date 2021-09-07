namespace TeacherWorkout.Domain.Models
{
    public class LessonSummaryStep : ILessonStep
    {
        public string Id { get; set; }

        public int ExperiencePoints { get; set; }

        public Lesson Lesson { get; set; }
    }
}