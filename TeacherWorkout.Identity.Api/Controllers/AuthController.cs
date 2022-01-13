using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeacherWorkout.Common.Authorization;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Users;
using TeacherWorkout.Identity.Api.Dtos;
using TeacherWorkout.Identity.Services;

namespace TeacherWorkout.Identity.Api.Controllers
{
    [Authorize]
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const string IncorrectEmailOrPassword = "Incorrect email or password.";
        private const string UserNotFound = "User with email {0} not found.";
        private const string DeleteUserError = "You can only delete your own account.";

        public AuthController(UserManager<IdentityUser> userManager, IJwtService jwtService, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
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

                await _userRepository.InsertAsync(new User
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
        
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
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
            var userDetails = await _userRepository.FindAsync(user.Email);

            return Ok(new
            {
                token = jwtToken,
                userDetails?.LastName,
                userDetails?.FirstName,
                Success = true
            });
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            var existingUser = await _userManager.FindByEmailAsync(userEmail);
            if (existingUser == null)
            {
                return BadRequest(string.Format(UserNotFound, userEmail));
            }

            var currentUser = _httpContextAccessor?.HttpContext?.User;
            var deletingCurrentUser = currentUser?.Claims.Any(c=> c.Type == "email" && c.Value == userEmail) ?? false;
            if (!deletingCurrentUser)
            {
                return BadRequest(DeleteUserError);
            }

            var result = await _userManager.DeleteAsync(existingUser);
            if (result.Succeeded)
            {
                await _userRepository.DeleteAsync(userEmail);
                return Ok();
            }

            return BadRequest(result);
        }

    }
}
