using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using TeacherWorkout.Domain.FileBlobs;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class FileBlobRepository(TeacherWorkoutContext context, ILogger<FileBlobRepository> customLogger) : IFileBlobRepository
    {
        private readonly TeacherWorkoutContext _context = context;
        private readonly ILogger<FileBlobRepository> _logger = customLogger;
        

        public void Add(FileBlob fileBlob)
        {
            _context.FileBlobs.Add(fileBlob);
            _context.SaveChanges();
        }

        public FileBlob Find(string id)
        {
            return _context.FileBlobs.FirstOrDefault(i => i.Id == id);
        }

        public List<FileBlob> FindRecent(string[] mimetypes, int? limit)
        {
            return _context.FileBlobs
                .Where(i => mimetypes.Contains(i.Mimetype))
                .OrderByDescending(i => i.CreatedAt)
                .Take(limit ?? 5)
                .ToList();
        }

        public void DeleteOldEntries(int daysInThePast)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysInThePast).ToUniversalTime();
            var oldEntries = _context.FileBlobs
                .Where(fb => fb.CreatedAt < cutoffDate && !_context.Images.Any(i => i.FileBlobId == fb.Id));
            _logger.LogInformation("Deleting {EntryCount} old file blobs", oldEntries.Count());
            _context.FileBlobs.RemoveRange(oldEntries);
            _context.SaveChanges();
        }
    }
}
