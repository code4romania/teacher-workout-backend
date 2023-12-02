using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.FileBlobs
{
    public class SingleUpload(IFileBlobRepository fileBlobRepository) : IOperation<SingleUploadInput, SingleUploadPayload>
    {
        private readonly IFileBlobRepository _fileBlobRepository = fileBlobRepository;

        public SingleUploadPayload Execute(SingleUploadInput input)
        {
            FileBlob fileBlob = new()
            {
                Content = input.Content,
                Mimetype = input.Mimetype.ToLower(),
                Description = input.FileName,
                CreatedAt = DateTime.UtcNow
            };

            // Validate extension
            string extension = System.IO.Path.GetExtension(input.FileName);
            if (!ImageUtils.Extensions.Contains(extension.ToLower()))
            {
                throw new ValidationException("Invalid image extension");
            }

            // Validate content type
            if (!ImageUtils.ContentTypes.Contains(fileBlob.Mimetype))
            {
                throw new ValidationException("Invalid image content type");
            }

            _fileBlobRepository.Add(fileBlob);

            return new SingleUploadPayload
            {
                FileBlobId = fileBlob.Id
            };
        }
    }
}
