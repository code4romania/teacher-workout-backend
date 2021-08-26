using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Entities
{
    public class ELesson : Lesson
    {
        public int? ThumbnailId { get; set; }
        
        public int ThemeId { get; set; }
    }
}
