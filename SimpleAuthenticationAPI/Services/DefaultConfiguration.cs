namespace SimpleAuthenticationAPI.Services
{
    /// <summary>
    /// This includes the details that will be seeded into the database once the application starts
    /// </summary>
    public class DefaultConfiguration
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
    }
}
