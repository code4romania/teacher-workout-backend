namespace TeacherWorkout.Domain.Common
{
    public interface IValidator
    {

    }

    public interface IValidator<T> : IValidator
    {
        public bool IsValid(T input);
    }
}
