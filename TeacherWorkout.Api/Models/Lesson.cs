namespace TeacherWorkout.Api.Models
{
    public class Lesson
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Image Thumbnail { get; set; }
        
        public Theme Theme { get; set; }
        
        public Duration Duration { get; set; }
    }
}