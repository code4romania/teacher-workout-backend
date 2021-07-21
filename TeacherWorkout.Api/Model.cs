using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Api.Models;
using dotenv.net.Utilities;

namespace TeacherWorkout.Api
{
    
    public class TeacherWorkoutContext : DbContext
    {
        public TeacherWorkoutContext(DbContextOptions<TeacherWorkoutContext> options) : base(options)
        {
        } 
        
        public DbSet<Theme> Themes { get; set; }
        
        public DbSet<Lesson> Lessons { get; set; }
        
        public DbSet<Answer> Answers { get; set; }
        
        public DbSet<SlideStep> SlideSteps { get; set; }
        
        public DbSet<ExerciseStep> ExerciseSteps { get; set; }
        
        public DbSet<LessonStepBase> Steps { get; set; }
        
        public DbSet<Image> Images { get; set; }

        public DbSet<LessonSummaryStep> LessonSummarySteps { get; set; }
        
        public DbSet<LessonStatus> LessonStatuses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(EnvReader.GetStringValue("DB_CONNECTION_STRING"));
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonStepBase>()
                .HasDiscriminator()
                .IsComplete(false);
        }
    }
}