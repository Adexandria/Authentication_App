using System.ComponentModel.DataAnnotations;

namespace SimpleAuthenticationAPI.Models.DTOs
{
    /// <summary>
    /// An object used to transfer data
    /// </summary>
    public class CreateUserDTO
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        [Required]
        public string LastName { get; set; }

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

        /// <summary>
        /// Password of the user
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RetypePassword { get; set; }
    }
}

