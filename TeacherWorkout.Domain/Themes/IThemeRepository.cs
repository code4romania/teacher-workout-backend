using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Themes
{
    public interface IThemeRepository
    {
        PaginatedResult<Theme> PaginatedList(PaginationFilter pagination);
        
        void Insert(Theme theme);

        Theme Find(string id);
        Theme Update(ThemeUpdateInput theme);
    }
}