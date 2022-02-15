using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Name = "Image";
            
            Field(x => x.Url, true).Description("URL to the image.");
            Field(x => x.Description, true).Description("Image description for accessibility.");
        }
    }
}