using System.Linq;
using TeacherWorkout.Domain.FileBlobs;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class FileBlobRepository(TeacherWorkoutContext context) : IFileBlobRepository
    {
        private readonly TeacherWorkoutContext _context = context;

        public void Add(FileBlob fileBlob)
        {
            _context.FileBlobs.Add(fileBlob);
            _context.SaveChanges();
        }

        public FileBlob Find(string id)
        {
            return _context.FileBlobs.FirstOrDefault(i => i.Id == id);
        }
    }
}
