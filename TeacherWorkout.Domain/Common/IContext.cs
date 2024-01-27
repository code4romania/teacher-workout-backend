using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Common
{
    public interface IContext 
    {
        public User CurentUser { get; }
    }
}
