namespace TeacherWorkout.Api.Models
{
    public class LessonSummaryStep : ILessonStep
    {
        public string Id { get; set; }

        public int ExperiencePoints { get; set; }
    }
}