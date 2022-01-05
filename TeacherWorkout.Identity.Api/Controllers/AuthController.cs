using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Users;
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
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, IJwtService jwtService, IUserRepository userRepository)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _userRepository = userRepository;
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
            await _userRepository.Insert(new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser == null)
            {
                return BadRequest("Incorrect email or password.");
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
            if (!passwordIsCorrect)
            {
                return BadRequest("Incorrect email or password.");
            }

            var jwtToken = _jwtService.GenerateToken(existingUser);
            var userDetails = await _userRepository.Find(user.Email);

            return Ok(new
            {
                token = jwtToken,
                userDetails.LastName,
                userDetails.FirstName,
                Success = true
            });
        }
    }
}
