using GraphQL.Types;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Types.Payloads
{
    public class StepSubmitAnswerPayloadType : ObjectGraphType<StepSubmitAnswerPayload>
    {
        public StepSubmitAnswerPayloadType()
        {
            Name = "StepSubmitAnswerPayload";

            Field(x => x.Step, type: typeof(StepUnionType)).Description("The completed step.");
            Field(x => x.LessonStatus).Description("The status of the lesson.");
        }

    }
}
