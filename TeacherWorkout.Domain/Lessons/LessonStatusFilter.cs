using System.Collections.Generic;

namespace TeacherWorkout.Domain.Lessons
{
    public class LessonStatusFilter
    {
        public IEnumerable<string> LessonIds { get; set; }
    }
}