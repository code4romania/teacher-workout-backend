using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface IStepRepository
    {
        ILessonStep Find(string id);

        ILessonStep CompleteStep(string id);
    }
}