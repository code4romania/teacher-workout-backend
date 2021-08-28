using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class StepCompleteInputType : InputObjectGraphType<StepCompleteInput>
    {
        public StepCompleteInputType()
        {
            Name = "StepCompleteInput";

            Field(x => x.StepId, type: typeof(NonNullGraphType<IdGraphType>));
        }
    }
}
