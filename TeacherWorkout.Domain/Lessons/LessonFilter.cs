using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public class LessonFilter : PaginationFilter
    {
        public string ThemeId { get; set; }
        public LessonState? State { get; set; }
        public string Term { get; set; }
    }
}
