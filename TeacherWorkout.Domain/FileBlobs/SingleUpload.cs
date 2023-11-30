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
                Mimetype = input.Mimetype,
                Description = input.FileName,
            };

            // Validate extension
            string extension = System.IO.Path.GetExtension(input.FileName);
            string[] imageExtensions = [".jpg", ".jpeg", ".png", ".gif"];
            if (!imageExtensions.Contains(extension.ToLower()))
            {
                throw new ValidationException("Invalid image extension");
            }

            // Validate content type
            string[] imageContentTypes = ["image/jpeg", "image/png", "image/gif"];
            if (!imageContentTypes.Contains(fileBlob.Mimetype.ToLower()))
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