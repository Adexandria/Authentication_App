namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// Manages Password Hashing and  verification
    /// </summary>
    public class PasswordManager : IPasswordManager
    {
        /// <summary>
        /// Hashes password
        /// </summary>
        /// <param name="password">Password of user</param>
        /// <param name="salt">Create unique hashes for the password</param>
        /// <returns>Hashed password</returns>
        public string HashPassword(string password, out string salt)
        {
            salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        /// <summary>
        /// Verify Passwords to check if they match
        /// </summary>
        /// <param name="password">Supposed password of the user</param>
        /// <param name="currentPassword">Current password of the user</param>
        /// <param name="salt">Create unique hashes for the password</param>
        /// <returns>True if passwords matches or false if they don't</returns>
        public bool VerifyPassword(string password, string currentPassword, string salt)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return currentPassword.Equals(hashedPassword);
        }
    }
}
