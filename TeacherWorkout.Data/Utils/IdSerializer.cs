using System;

namespace TeacherWorkout.Data.Utils
{
    public static class IdSerializer
    {
        public static string Serialize(int? id)
        {
            return id?.ToString();
        }

        public static int? Deserialize(string id)
        {
            return Convert.ToInt32(id);
        }
    }
}