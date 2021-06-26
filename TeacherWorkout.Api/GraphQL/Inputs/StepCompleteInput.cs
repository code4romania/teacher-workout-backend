using GraphQL.Types;

namespace TeacherWorkout.Api.GraphQL.Inputs
{
    public class StepCompleteInput : InputObjectGraphType
    {
        public StepCompleteInput()
        {
            Name = "StepCompleteInput";
            Field<IdGraphType>("stepId");
        }
    }
}