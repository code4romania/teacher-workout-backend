using System.Collections.Generic;

namespace TeacherWorkout.Api.Models
{
    public class Theme : IIdentifiable
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Image Thumbnail { get; set; }
        
        public IEnumerable<Lesson> Lessons { get; set; }
    }
}