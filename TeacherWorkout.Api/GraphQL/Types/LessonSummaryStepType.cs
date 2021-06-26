using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonSummaryStepType : ObjectGraphType<LessonSummaryStep>
    {
        public LessonSummaryStepType()
        {
            Name = "LessonSummaryStep";
            
            Interface<LessonStepInterface>();
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.ExperiencePoints).Description("Total experience points for the lesson");
        }
    }
}