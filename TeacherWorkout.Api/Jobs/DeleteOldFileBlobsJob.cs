using Microsoft.Extensions.Options;
using TeacherWorkout.Api.Jobs.Interfaces;
using TeacherWorkout.Domain.FileBlobs;
using TeacherWorkout.Api.Jobs.Config;

namespace TeacherWorkout.Api.Jobs
{

    public class DeleteOldFileBlobsJob(IFileBlobRepository repository, IOptions<DeleteOldFileBlobsConfig> config) : IDeleteOldFileBlobsJob
    {
        private readonly IFileBlobRepository _repository = repository;
        private readonly DeleteOldFileBlobsConfig _config = config.Value;
        
        public void Run()
        {
            ;
            _repository.DeleteOldEntries(_config.DaysInThePast);
        }
    }
}
