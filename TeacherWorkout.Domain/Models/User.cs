using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Models
{
    public class User : IIdentifiable
    {
        public string Id { get; set; }

        public string Name { get; set; }

    }
}
