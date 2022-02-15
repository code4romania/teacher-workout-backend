using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonType : ObjectGraphType<Lesson>
    {
        public LessonType()
        {
            Name = "Lesson";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title, true).Description("The title of the Lesson");
            Field(x => x.Description, true).Description("The description of the Lesson");
            Field(x => x.Thumbnail, true).Description("The thumbnail of the Lesson");
            Field(x => x.Theme, true).Description("The Theme of the Lesson");
            Field(x => x.Duration, true).Description("The duration of the Lesson");
            Field(x => x.State).Description("The state of the Lesson.");
        }
    }
}
