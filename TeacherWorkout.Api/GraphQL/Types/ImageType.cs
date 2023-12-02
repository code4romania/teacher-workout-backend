using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Name = "Image";
            
            Field(x => x.Url, true).Description("URL to the image. If null, use FileBlob ID to generate an URL: /file/<fileBlobId>");
            Field(x => x.Description, true).Description("Image description for accessibility.");
            Field(x => x.FileBlobId, true).Description("Reference to local file. If null, use Url property.");
        }
    }
}