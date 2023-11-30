
using System;
using TeacherWorkout.Domain.Common;

namespace TeacherWorkout.Domain.Models
{
    public class FileBlob : IIdentifiable
    {
        public string Id { get; set; }
        public byte[] Content { get; set; }
        public string Mimetype { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
