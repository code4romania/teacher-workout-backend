namespace TeacherWorkout.Domain.Models
{
    public class SlideStep : ILessonStep
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }

        public ILessonStep PreviousStep { get; set; }

        public Lesson Lesson { get; set; }
    }
}