using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data
{
    public class TeacherWorkoutContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Lesson>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<StringValueGenerator>();

            modelBuilder.Entity<Lesson>()
                .HasIndex("ThemeId", "State");

            modelBuilder.Entity<Theme>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<StringValueGenerator>();

            modelBuilder.Entity<Image>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<StringValueGenerator>();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
        }
    }
}
