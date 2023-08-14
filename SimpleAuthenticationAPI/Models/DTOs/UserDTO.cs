namespace SimpleAuthenticationAPI.Models.DTOs
{
    /// <summary>
    /// An object used to display user details
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="email">Email address of the user</param>

        public UserDTO(string firstName, string lastName, string email)
        {
            Name = $"{firstName} {lastName}";
            Email = email;
        }
        /// <summary>
        /// First name and last name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }
    }
}
