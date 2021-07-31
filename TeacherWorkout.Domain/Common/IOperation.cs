namespace TeacherWorkout.Domain.Common
{
    public interface IOperation
    {
    }
    
    public interface IOperation<TInput, TResult> : IOperation
    {
        TResult Execute(TInput input);
    }
}