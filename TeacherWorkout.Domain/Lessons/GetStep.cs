using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public class GetStep : IOperation<StepFindInput, ILessonStep>
    {
        private readonly IStepRepository _repository;

        public GetStep(IStepRepository repository)
        {
            _repository = repository;
        }
        
        public ILessonStep Execute(StepFindInput filter)
        {
            return _repository.Find(filter.Id);
        }
    }
}