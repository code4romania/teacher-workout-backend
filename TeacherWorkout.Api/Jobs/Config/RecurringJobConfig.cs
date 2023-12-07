namespace TeacherWorkout.Api.Jobs.Config
{
    public record RecurringJobConfig
    {
        public bool IsEnabled { get; set; }
        public string CronExpression { get; set; }
    }
}
