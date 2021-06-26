using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonSavePayloadType : ObjectGraphType<LessonSavePayload>
    {
        public LessonSavePayloadType()
        {
            Name = "LessonSavePayload";
            
            Field(x => x.Lesson).Description("The newly created lesson.");
        }
    }
}