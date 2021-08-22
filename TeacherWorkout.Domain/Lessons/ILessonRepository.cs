using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface ILessonRepository
    {
        PaginatedResult<Lesson> PaginatedList(PaginationFilter pagination, IEnumerable<IFilter> filters);
    }
}