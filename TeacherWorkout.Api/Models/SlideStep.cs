namespace TeacherWorkout.Api.Models
{
    public class SlideStep : LessonStepBase
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Image Image { get; set; }

        public LessonStepBase PreviousStep { get; set; }
    }
}