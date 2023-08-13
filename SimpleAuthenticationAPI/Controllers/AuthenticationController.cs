using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthenticationAPI.Models;
using SimpleAuthenticationAPI.Models.DTOs;
using SimpleAuthenticationAPI.Services.Authorization;
using SimpleAuthenticationAPI.Services.Repositories;

namespace SimpleAuthenticationAPI.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IAuthRepository _authRepository;
        public AuthenticationController(IUserRepository userRepository,IPasswordManager passwordManager, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _authRepository = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("user/sign-up")]
        public async Task<IActionResult> SignUpUser(CreateUserDTO newUser)
        {
            var isExists = await _userRepository.ExistsAsync(newUser.Email);
            if (isExists)
                return BadRequest("Email already exists");
            
            var hashedPassword = _passwordManager.HashPassword(newUser.Password, out string salt);
            var user = new User(newUser.FirstName, newUser.LastName, newUser.Email, Role.User).SetPassword(hashedPassword,salt);
            
            var response = await _userRepository.AddUser(user);
            if (!response)
                return BadRequest("Failed to create user");

            return Ok("Successful");
        }
        
        [HasRole(Role.Admin)]
        [HttpPost("admin/sign-up")]
        public async Task<IActionResult> SignUpAdmin(CreateUserDTO newUser)
        {
            var isExists = await _userRepository.ExistsAsync(newUser.Email);
            if (isExists)
                return BadRequest("Email already exists");

            var hashedPassword = _passwordManager.HashPassword(newUser.Password, out string salt);
            var user = new User(newUser.FirstName, newUser.LastName, newUser.Email, Role.Admin).SetPassword(hashedPassword, salt);

            var response = await _userRepository.AddUser(user);
            if (!response)
                return BadRequest("Failed to create user");

            return Ok("Successful");
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(LoginDTO login)
        {
            var user = await _userRepository.GetUserByEmail(login.Email);
            if (user == null)
                return BadRequest("Invalid email or password");

            var hashedPassword = _passwordManager.VerifyPassword(login.Password, user.PasswordHash, user.Salt);
            if (!hashedPassword)
                return BadRequest("Invalid email or password");

            var generatedToken = _authRepository.GenerateAccessToken(user.Id, user.Role.ToString());
            
            var userDTO = new UserDTO(user.FirstName, user.LastName, generatedToken);
            
            return Ok(userDTO);
        }
    }
}
