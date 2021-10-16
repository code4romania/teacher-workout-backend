using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Themes
{
    public interface IThemeRepository
    {
        PaginatedResult<Theme> PaginatedList(PaginationFilter pagination);
        
        void Insert(Theme theme);
    }
}