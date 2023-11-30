using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.FileBlobs
{
    public interface IFileBlobRepository
    {
        void Add(FileBlob fileBlob);
        FileBlob Find(string id);
    }
}