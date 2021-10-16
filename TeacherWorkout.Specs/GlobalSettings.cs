using System;

namespace TeacherWorkout.Specs
{
    public class GlobalSettings
    {
        public static bool IsCi => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "CI";
    }
}