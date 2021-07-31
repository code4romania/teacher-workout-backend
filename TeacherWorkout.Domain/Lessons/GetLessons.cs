using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Lessons
{
    public class GetLessons : IOperation<GetLessons.Input, PaginatedResult<Lesson>>
    {
        public class Input : PaginationInput
        {
            public int ThemeId { get; set; }
        }
        
        private readonly ILessonRepository _repository;

        public GetLessons(ILessonRepository repository)
        {
            _repository = repository;
        }
        
        public PaginatedResult<Lesson> Execute(Input input)
        {
            return _repository.PaginatedList(input.ToPaginationFilter(), new List<IFilter> { new ThemeFilter(input.ThemeId) });
        }
    }
}