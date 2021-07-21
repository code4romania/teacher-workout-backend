namespace TeacherWorkout.Api.Models
{
    public class Answer : IIdentifiable
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public bool Correct { get; set; }
        
        public ExerciseStep Step { get; set; }
    }
}