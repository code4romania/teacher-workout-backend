using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class ThemeCreateInputType : InputObjectGraphType<ThemeCreateInput>
    {
        public ThemeCreateInputType()
        {
            Name = "ThemeCreateInput";

            Field(x => x.Title);
            Field(x => x.FileBlobId, true, type: typeof(IdGraphType))
                .Description("Id of uploaded image blob (precedes and overwrites ThumbnailId)");
            Field(x => x.ThumbnailId, true, type: typeof(IdGraphType))
                .Description("Id of existing thumbnail");
        }
    }
}
