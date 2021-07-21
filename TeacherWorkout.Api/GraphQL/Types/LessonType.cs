using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonType : ObjectGraphType<Lesson>
    {
        public LessonType()
        {
            Name = "Lesson";
            
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title).Description("The title of the Lesson");
            Field(x => x.Thumbnail).Description("The thumbnail of the Lesson");
            Field(x => x.Theme).Description("The Theme of the Lesson");
        }
    }
}