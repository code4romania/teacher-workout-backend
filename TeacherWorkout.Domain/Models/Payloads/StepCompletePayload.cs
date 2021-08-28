namespace TeacherWorkout.Domain.Models.Payloads
{
    public class StepCompletePayload
    {
        public ILessonStep Step { get; set; }

        public LessonStatus LessonStatus { get; set; }
    }
}
