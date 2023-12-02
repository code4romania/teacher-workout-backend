using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.FileBlobs
{
    public class GetFileBlobs(IFileBlobRepository repository) : IOperation<int, List<FileBlob>>
    {
        private readonly IFileBlobRepository _repository = repository;

        public List<FileBlob> Execute(int limit)
        {
            return _repository.FindRecent(ImageUtils.ContentTypes, limit);
        }
    }
}
