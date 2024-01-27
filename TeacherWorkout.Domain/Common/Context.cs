using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Common
{
    public class Context : IContext
    {
        public User CurentUser { get; set; }
    }
}
