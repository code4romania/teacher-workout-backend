using System.Collections.Generic;
using System.Linq;

namespace TeacherWorkout.Domain.Common
{
    public interface IRepository<TSource>
    {
        PaginatedResult<TSource> PaginatedList(PaginationFilter pagination);
        
        PaginatedResult<TSource> PaginatedList(PaginationFilter pagination, IEnumerable<IFilter> filters);
    }
}