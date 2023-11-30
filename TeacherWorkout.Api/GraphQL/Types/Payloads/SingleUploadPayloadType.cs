using System;
using GraphQL.Types;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Types.Payloads
{
    public class SingleUploadPayloadType : ObjectGraphType<SingleUploadPayload>
    {
        public SingleUploadPayloadType()
        {
            Name = "SingleUploadPayload";

            Field(x => x.FileBlobId).Description("The ID of the created file blob.");
        }
    }
}
