using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Models
{
    public class Answer : IIdentifiable
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
    }
}