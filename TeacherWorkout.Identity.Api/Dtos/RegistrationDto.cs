using System.ComponentModel.DataAnnotations;

namespace TeacherWorkout.Identity.Api.Dtos
{
    public class RegistrationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}