namespace TeacherWorkout.Domain.Models.Inputs
{
    public class SingleUploadInput
    {
        public string FileName { get; set; }
        public string Mimetype { get; set; }
        public string Encoding { get; set; }
        public byte[] Content { get; set; }
    }
}
