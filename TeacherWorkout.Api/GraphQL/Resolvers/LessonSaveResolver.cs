using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Resolvers

{
    public class LessonSaveResolver : IOperation<LessonSaveInput, LessonSavePayload>
    {

        private IContext _context;
        private ILessonStatusRepository _lessonStatusRepository;
        private ILessonRepository _lessonRepository;
        
        public LessonSaveResolver (IContext context, ILessonStatusRepository lessonStatusRepository, ILessonRepository lessonRepository)
        {
            _context = context;
            _lessonStatusRepository = lessonStatusRepository;
            _lessonRepository = lessonRepository;

        }
        
        public LessonSavePayload Execute(LessonSaveInput input)
        {
            Lesson lesson = _lessonRepository.Find(input.LessonId);

            _lessonStatusRepository.Insert(new LessonStatus()
            {
                Lesson = lesson,
                PercentCompleted = 0,
                User = _context.CurentUser
            });

            return new LessonSavePayload()
            {
                Lesson = lesson
            };
        }

       

    }
}