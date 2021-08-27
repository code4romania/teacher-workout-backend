using System.Collections.Generic;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface ILessonStatusRepository
    {
        IEnumerable<LessonStatus> List(LessonStatusFilter filter);
    }
}