using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonStatusType : ObjectGraphType<LessonStatus>
    {
        public LessonStatusType()
        {
            Name = "LessonStatus";

            Field(x => x.Lesson).Description("The lesson.");
            Field(x => x.PercentCompleted).Description("Percentage (%) of how much of the lesson has been completed.");
            Field(x => x.CurrentLessonStep).Description("The current lesson step.");
        }
    }
}