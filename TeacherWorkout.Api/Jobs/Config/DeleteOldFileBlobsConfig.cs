namespace TeacherWorkout.Api.Jobs.Config
{
    public record DeleteOldFileBlobsConfig : RecurringJobConfig
    {
        public int DaysInThePast { get; set; }
    }
}