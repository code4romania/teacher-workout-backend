using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Lessons
{
    public class ThemeFilter : IFilter
    {
        public int ThemeId { get; }

        public ThemeFilter(int themeId)
        {
            ThemeId = themeId;
        }
    }
}