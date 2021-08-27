using System.Collections.Generic;

namespace TeacherWorkout.Domain.Common
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}