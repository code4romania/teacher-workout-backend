using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.MockData.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        public PaginatedResult<Lesson> PaginatedList(PaginationFilter pagination)
        {
            return PaginatedList(pagination, Enumerable.Empty<IFilter>());
        }

        public PaginatedResult<Lesson> PaginatedList(PaginationFilter pagination, IEnumerable<IFilter> input)
        {
            return new PaginatedResult<Lesson>
            {
                TotalCount = 11,
                Items = new List<Lesson>()
            };
        }
    }
}
