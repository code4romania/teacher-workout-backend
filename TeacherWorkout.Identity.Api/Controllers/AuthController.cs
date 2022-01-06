using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherWorkout.Common.Authorization;
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

        private const string IncorrectEmailOrPassword = "Incorrect email or password.";

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

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, AuthorizationRoles.User);

                await _userRepository.Insert(new User
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                });

                //todo decide if we need to confirm the email before we allow the user to login

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser == null)
            {
                return BadRequest(IncorrectEmailOrPassword);
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
            if (!passwordIsCorrect)
            {
                return BadRequest(IncorrectEmailOrPassword);
            }

            var userRoles = await _userManager.GetRolesAsync(existingUser);
            var jwtToken = _jwtService.GenerateToken(existingUser, userRoles);
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
