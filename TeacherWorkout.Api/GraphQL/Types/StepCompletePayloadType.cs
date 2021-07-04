using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class StepCompletePayloadType : ObjectGraphType<StepCompletePayload>
    {
        public StepCompletePayloadType()
        {
            Name = "StepCompletePayload";
            
            Field(x => x.Step, type: typeof(StepUnionType)).Description("The completed step.");
            Field(x => x.LessonStatus).Description("The status of the lesson.");
        }
    }
}