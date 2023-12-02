using System.IO;
using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Models
{
    public class Image : IIdentifiable
    {
        public string Id { get; set; }
        
        public string Description { get; set; }

        public string Url { get; set; }
        
        public string FileBlobId { get; set; }
        public FileBlob FileBlob { get; set; }
    }
}