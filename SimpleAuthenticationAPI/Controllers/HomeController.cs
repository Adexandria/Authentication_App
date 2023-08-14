using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthenticationAPI.Models;
using SimpleAuthenticationAPI.Models.DTOs;
using SimpleAuthenticationAPI.Services.Authorization;
using SimpleAuthenticationAPI.Services.Repositories;

namespace SimpleAuthenticationAPI.Controllers
{
    /// <summary>
    /// This displays the information users
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="userRepository">An instance to manage the operations of a user</param>
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Displays the authorised user details
        /// </summary>
        /// <returns>A action result</returns>
        [HttpGet("account-details")]
        public async Task<IActionResult> GetUserDetails()
        {
            Guid currentUserId = new(User.Claims.First(s => s.Type == "id").Value);
            if(currentUserId == Guid.Empty)
                return Unauthorized();

            var user = await _userRepository.GetUserById(currentUserId);
            if(user == null)
                return NotFound("user does not exist");

            var userDTO = new UserDTO(user.FirstName, user.LastName, user.Email);

            return Ok(userDTO);
        }

        /// <summary>
        /// Get all users with user role
        /// </summary>
        /// <returns>A action result</returns>
        [HasRole(Role.Admin)]
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsersRoleType();

            var userDTOs = users.Select(s=> new UserDTO(s.FirstName, s.LastName,s.Email)).ToList();

            return Ok(userDTOs);
        }
    }
}
