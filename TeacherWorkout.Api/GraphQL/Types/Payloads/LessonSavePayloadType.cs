using GraphQL.Types;
using TeacherWorkout.Api.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Types.Payloads
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