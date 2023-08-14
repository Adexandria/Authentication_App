namespace SimpleAuthenticationAPI.Models
{
    /// <summary>
    /// An object that is use to hold details about the user
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// A constructor
        /// </summary>
        protected User() { }

        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="email">Email address of the user</param>
        /// <param name="role">Role of the user</param>
        public User(string firstName, string lastName, string email,Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }

        /// <summary>
        /// Set a user password
        /// </summary>
        /// <param name="passwordHash">Hashed password</param>
        /// <param name="salt">Create unique hashes for the password</param>
        /// <returns>A user</returns>
        public User SetPassword(string passwordHash, string salt)
        {
            PasswordHash = passwordHash;
            Salt = salt;
            return this;
        }
        
        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Hashed password of the user
        /// </summary>
        public string PasswordHash { get; protected set; }

        /// <summary>
        /// Create unique hashes for the password
        /// </summary>
        public string Salt { get; protected set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Role of the user
        /// </summary>
        public Role Role { get; set; }
    }
}
