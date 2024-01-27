using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Resolvers;

public class LessonSave(IContext context, ILessonStatusRepository lessonStatusRepository, ILessonRepository lessonRepository) : IOperation<LessonSaveInput, LessonSavePayload>
{
    private readonly IContext _context = context;
    private readonly ILessonStatusRepository _lessonStatusRepository = lessonStatusRepository;
    private readonly ILessonRepository _lessonRepository = lessonRepository;

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
