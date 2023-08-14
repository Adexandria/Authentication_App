using System.ComponentModel.DataAnnotations;

namespace SimpleAuthenticationAPI.Models.DTOs
{
    /// <summary>
    /// An object used to log in user
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Email address of the user
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
