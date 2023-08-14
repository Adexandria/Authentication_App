using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthenticationAPI.Models;
using SimpleAuthenticationAPI.Models.DTOs;
using SimpleAuthenticationAPI.Services.Authorization;
using SimpleAuthenticationAPI.Services.Repositories;

namespace SimpleAuthenticationAPI.Controllers
{
    /// <summary>
    /// Manages the authentication interactions
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IAuthRepository _authRepository;

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="userRepository">An instance to manage the operations of a user</param>
        /// <param name="passwordManager">An instance to manage passwords of a user</param>
        /// <param name="authRepository">An instance to create token for the user</param>
        public AuthenticationController(IUserRepository userRepository,IPasswordManager passwordManager, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _authRepository = authRepository;
        }

        /// <summary>
        /// Sign ups a user with a user role
        /// </summary>
        /// <param name="newUser">An object used to create a new user</param>
        /// <returns>An Action result</returns>
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

        /// <summary>
        /// Sign ups a user with a user role
        /// </summary>
        /// <param name="newUser">An object used to create a new user</param>
        /// <returns>An Action result</returns>
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

        /// <summary>
        /// Sign in user. This includes all roles
        /// </summary>
        /// <param name="loginDTO">An object used to login users</param>
        /// <returns>An Action result</returns>
        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmail(loginDTO.Email);
            if (user == null)
                return BadRequest("Invalid email or password");

            var hashedPassword = _passwordManager.VerifyPassword(loginDTO.Password, user.PasswordHash, user.Salt);
            if (!hashedPassword)
                return BadRequest("Invalid email or password");

            var generatedToken = _authRepository.GenerateAccessToken(user.Id, user.Role.ToString());
            
            var userDTO = new UserTokenDTO(user.FirstName, user.LastName, generatedToken);
            
            return Ok(userDTO);
        }
    }
}
