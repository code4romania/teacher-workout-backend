using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ExerciseStepType : ObjectGraphType<ExerciseStep>
    {
        public ExerciseStepType()
        {
            Name = "ExerciseStep";
            
            Interface<LessonStepInterface>();
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Question).Description("The question");
            Field(x => x.Answers).Description("The possible possible answers");

            IsTypeOf = obj => obj is ExerciseStep;
        }
    }
}