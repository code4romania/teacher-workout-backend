using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Models
{
    public class Theme : IIdentifiable
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Image Thumbnail { get; set; }
    }
}