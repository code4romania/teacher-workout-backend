namespace TeacherWorkout.Api.Models
{
    public class LessonStatus
    {
        public int PercentCompleted { get; set; }

        public ILessonStep CurrentLessonStep { get; set; }
    }
}