namespace TeacherWorkout.Identity.Options
{
    public class JwtConfig
    {
        public const string SectionName = nameof(JwtConfig);

        public string Secret { get; set; }
        public int TokenExpirationInSeconds { get; set; }
    }
}