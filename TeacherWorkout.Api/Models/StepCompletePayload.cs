using TeacherWorkout.Api.GraphQL.Types;

namespace TeacherWorkout.Api.Models
{
    public class StepCompletePayload
    {
        public ILessonStep Step { get; set; }
    }
}