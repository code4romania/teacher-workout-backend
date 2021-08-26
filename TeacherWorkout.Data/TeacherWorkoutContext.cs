using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data
{
    public class TeacherWorkoutContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Theme> Themes { get; set; }

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
            var idConverter = new ValueConverter<string, int>(
                from => Convert.ToInt32(from),
                to => to.ToString()
            );

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Duration)
                .HasConversion(converter);

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Id)
                .HasConversion(idConverter);
            
            modelBuilder.Entity<Theme>()
                .Property(l => l.Id)
                .HasConversion(idConverter);
            
            modelBuilder.Entity<Image>()
                .Property(l => l.Id)
                .HasConversion(idConverter);
        }
    }
}
