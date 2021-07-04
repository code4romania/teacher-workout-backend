using TeacherWorkout.Api.GraphQL.Types;

namespace TeacherWorkout.Api.Models
{
    public class LessonSave
    {
        private string _lessonId;
        public dynamic LessonId
        {
            get => _lessonId;
            set => _lessonId = value.ToString();
        }
    }
}