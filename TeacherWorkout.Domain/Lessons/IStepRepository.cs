using System.Collections.Generic;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface IStepRepository
    {
        ILessonStep Find(string id);

        ILessonStep CompleteStep(string id);

        ILessonStep SubmitAnswer(string id, IEnumerable<string> answerIds);
    }
}