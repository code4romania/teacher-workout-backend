using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Themes
{
    public class GetThemes : IOperation<PaginationFilter, PaginatedResult<Theme>>
    {
        private readonly IThemeRepository _repository;

        public GetThemes(IThemeRepository repository)
        {
            _repository = repository;
        }
        
        public PaginatedResult<Theme> Execute(PaginationFilter filter)
        {
            return _repository.PaginatedList(filter);
        }
    }
}