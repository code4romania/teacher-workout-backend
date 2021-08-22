using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Lessons
{
    public class LessonFilter : PaginationFilter
    {
        public int? ThemeId { get; set; }
    }
}