using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Lessons
{
    public class LessonFilter : PaginationFilter
    {
        public string ThemeId { get; set; }
    }
}