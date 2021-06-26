using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ExerciseSummaryStepType : ObjectGraphType<ExerciseSummaryStep>
    {
        public ExerciseSummaryStepType()
        {
            Name = "ExerciseSummaryStep";
            
            Interface<LessonStepInterface>();
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Results).Description("Answer Results");
        }
    }
}