using GraphQL.Types;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class StepUnionType : UnionGraphType
    {
        public StepUnionType()
        {
            Name = "StepUnion";

            Type<SlideStepType>();
            Type<ExerciseStepType>();
            Type<LessonSummaryStepType>();
            Type<ExerciseSummaryStepType>();
        }
    }
}