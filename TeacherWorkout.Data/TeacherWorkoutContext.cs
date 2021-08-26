using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherWorkout.Data.Entities;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data
{
    public class TeacherWorkoutContext : DbContext
    {
        public DbSet<ELesson> Lessons { get; set; }
        public DbSet<ETheme> Themes { get; set; }

        public TeacherWorkoutContext(DbContextOptions<TeacherWorkoutContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var converter = new ValueConverter<Duration, int>(
                from => from.TotalSeconds,
                to => Duration.FromSeconds(to)
            );

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Duration)
                .HasConversion(converter);
        }
    }
}
