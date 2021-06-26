using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ThemeType : ObjectGraphType<Theme>
    {
        public ThemeType()
        {
            Name = "Theme";
            
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title).Description("The title of the Theme");
            Field(x => x.Thumbnail).Description("The thumbnail of the Theme");
        }
    }
}