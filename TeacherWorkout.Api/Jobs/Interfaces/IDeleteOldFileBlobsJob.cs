using System.Threading;
using System.Threading.Tasks;

namespace TeacherWorkout.Api.Jobs.Interfaces
{
    public interface IDeleteOldFileBlobsJob
    {
        void Run();
    }
}