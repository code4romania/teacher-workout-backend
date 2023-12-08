using System.Collections.Generic;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.FileBlobs
{
    public interface IFileBlobRepository
    {
        void Add(FileBlob fileBlob);
        FileBlob Find(string id);
        List<FileBlob> FindRecent(string[] mimetypes, int? limit);
        void DeleteOldEntries(int daysInThePast);
    }
}