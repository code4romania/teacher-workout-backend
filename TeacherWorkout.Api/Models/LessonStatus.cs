namespace TeacherWorkout.Api.Models
{
    public class LessonStatus
    {
        public Lesson Lesson { get; set; }
        
        public int PercentCompleted { get; set; }

        public ILessonStep CurrentLessonStep { get; set; }
    }
}