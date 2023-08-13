using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthenticationAPI.Models.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string RetypePassword { get; set; }
    }
}

