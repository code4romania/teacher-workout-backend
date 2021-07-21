using System.Collections.Generic;

namespace TeacherWorkout.Api.Models
{
    public class ExerciseStep : LessonStepBase
    {
        public string Question { get; set; }
        
        public IEnumerable<Answer> Answers { get; set; }
    }
}