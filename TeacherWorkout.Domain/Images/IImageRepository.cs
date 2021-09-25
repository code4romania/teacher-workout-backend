using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Images
{
    public interface IImageRepository
    {
        Image Find(string id);
    }
}