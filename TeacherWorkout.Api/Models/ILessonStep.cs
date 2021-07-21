namespace TeacherWorkout.Api.Models
{
    public interface ILessonStep : IIdentifiable
    {
    }
    
    public abstract class LessonStepBase : ILessonStep
    {
        public string Id { get; set; }
        
        public Lesson Lesson { get; set; }
    }
}