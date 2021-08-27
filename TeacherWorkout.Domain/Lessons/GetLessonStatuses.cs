using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public class GetLessonStatuses : IOperation<LessonStatusFilter, IEnumerable<LessonStatus>>
    {
        private readonly ILessonStatusRepository _repository;

        public GetLessonStatuses(ILessonStatusRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<LessonStatus> Execute(LessonStatusFilter filter)
        {
            return _repository.List(filter);
        }
    }
}