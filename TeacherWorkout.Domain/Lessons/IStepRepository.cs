using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Lessons
{
    public interface IStepRepository
    {
        ILessonStep Find(string id);

        ILessonStep CompleteStep(string id);
    }
}