using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Lessons
{
    public class GetLessons : IOperation<LessonFilter, PaginatedResult<Lesson>>
    {
        private readonly ILessonRepository _repository;

        public GetLessons(ILessonRepository repository)
        {
            _repository = repository;
        }
        
        public PaginatedResult<Lesson> Execute(LessonFilter filter)
        {
            return _repository.PaginatedList(filter);
        }
    }
}