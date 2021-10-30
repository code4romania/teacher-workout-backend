using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class StepSubmitAnswerInputType : InputObjectGraphType<StepSubmitAnswerInput>
    {
        public StepSubmitAnswerInputType()
        {
            Name = "StepSubmitAnswerInput";

            Field(x => x.StepId, type: typeof(NonNullGraphType<IdGraphType>));
            Field(x => x.AnswerIds, type: typeof(ListGraphType<IdGraphType>));
        }
    }
}
