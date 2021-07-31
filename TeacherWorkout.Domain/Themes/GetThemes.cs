using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Themes
{
    public class GetThemes : IOperation<GetThemes.Input, PaginatedResult<Theme>>
    {
        public class Input : PaginationInput
        {
        }
        
        private readonly IThemeRepository _repository;

        public GetThemes(IThemeRepository repository)
        {
            _repository = repository;
        }
        
        public PaginatedResult<Theme> Execute(Input input)
        {
            return _repository.PaginatedList(input.ToPaginationFilter());
        }
    }
}