using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Lessons
{
    public interface IAnswerRepository
    {
        public Answer Find(string id);
    }
}
