using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherWorkout.Identity.Api.Dtos;
using TeacherWorkout.Identity.Services;

namespace TeacherWorkout.Identity.Api.Controllers
{
    [AllowAnonymous]
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto user)
        {
            var foundUser = await _userManager.FindByEmailAsync(user.Email);

            if (foundUser != null)
            {
                return new BadRequestObjectResult("Email already in use");
            }

            var newUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Email
            };

            //todo decide if we need to confirm the email before we allow the user to login
            var result = await _userManager.CreateAsync(newUser, user.Password);

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            if (existingUser == null)
            {
                return BadRequest();
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
            if (!passwordIsCorrect)
            {
                return BadRequest();
            }

            var jwtToken = _jwtService.GenerateToken(existingUser);

            return Ok(new
            {
                token = jwtToken,
                //userDetails.Value.LastName,
                //userDetails.Value.FirstName,
                Success = true
            });
        }
    }
}
