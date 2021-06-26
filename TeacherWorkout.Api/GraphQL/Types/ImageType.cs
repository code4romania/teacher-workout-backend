using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Name = "Image";
            
            Field(x => x.Url).Description("URL to the image.");
            Field(x => x.Description).Description("Image description for accessibility.");
        }
    }
}