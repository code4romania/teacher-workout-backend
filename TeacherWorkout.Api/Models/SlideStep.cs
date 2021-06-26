namespace TeacherWorkout.Api.Models
{
    public class SlideStep : ILessonStep
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Image Image { get; set; }

        public ILessonStep PreviousStep { get; set; }
        public string Id { get; set; }
    }
}