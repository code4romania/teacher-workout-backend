using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class FileBlobType : ObjectGraphType<FileBlob>
    {
        public FileBlobType()
        {
            Name = "FileBlob";

            Field(x => x.Id, nullable: false).Description("The unique identifier of the file blob.");
            Field(x => x.CreatedAt, nullable: false).Description("The creation time of the file blob.");
        }
    }
}
