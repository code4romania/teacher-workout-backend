using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class ThemeCreateInputType : InputObjectGraphType<ThemeCreateInput>
    {
        public ThemeCreateInputType()
        {
            Name = "ThemeCreateInput";

            Field(x => x.ThumbnailId, type: typeof(IdGraphType));
            Field(x => x.Title);
        }
    }
}
