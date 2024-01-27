using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons;

public class GetStep(IStepRepository repository) : IOperation<StepFindInput, ILessonStep>
{
    private readonly IStepRepository _repository = repository;

    public ILessonStep Execute(StepFindInput filter)
    {
        return _repository.Find(filter.Id);
    }
}
