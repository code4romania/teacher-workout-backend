namespace TeacherWorkout.Domain.Models.Payloads
{
    public class StepSubmitAnswerPayload
    {
        public ILessonStep Step { get; set; }

        public LessonStatus LessonStatus { get; set; }
    }
}
