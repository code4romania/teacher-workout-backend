using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons;

public class GetLessonStatuses(ILessonStatusRepository repository) : IOperation<LessonStatusFilter, IEnumerable<LessonStatus>>
{
    private readonly ILessonStatusRepository _repository = repository;

    public IEnumerable<LessonStatus> Execute(LessonStatusFilter filter)
    {
        return _repository.List(filter);
    }
}
