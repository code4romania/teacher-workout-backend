using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class ThemeUpdateInputType : InputObjectGraphType<ThemeUpdateInput>
    {
        public ThemeUpdateInputType()
        {
            Name = "ThemeUpdateInput";

            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.ThumbnailId, type: typeof(IdGraphType));
            Field(x => x.Title);
        }
    }
}
