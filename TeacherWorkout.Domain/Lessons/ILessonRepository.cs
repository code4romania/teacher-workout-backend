using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface ILessonRepository
    {
        PaginatedResult<Lesson> PaginatedList(LessonFilter filter);
    }
}