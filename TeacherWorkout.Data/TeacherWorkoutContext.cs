using Microsoft.EntityFrameworkCore;
using System;
using TeacherWorkout.Data.Entities;

namespace TeacherWorkout.Data
{
    public class TeacherWorkoutContext : DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }

        public TeacherWorkoutContext(DbContextOptions<TeacherWorkoutContext> options) : base(options)
        {

        }
    }
}
