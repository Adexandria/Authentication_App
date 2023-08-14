namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// Manages  Password Hashing and verification
    /// </summary>
    public interface IPasswordManager
    {
        /// <summary>
        /// Hashes password
        /// </summary>
        /// <param name="password">Password of user</param>
        /// <param name="salt">Create unique hashes for the password</param>
        /// <returns>Hashed password</returns>
        string HashPassword(string password, out string salt);

        /// <summary>
        /// Verify Passwords to check if they match
        /// </summary>
        /// <param name="password">Supposed password of the user</param>
        /// <param name="currentPassword">Current password of the user</param>
        /// <param name="salt">Create unique hashes for the password</param>
        /// <returns>True if passwords matches or false if they don't</returns>
        bool VerifyPassword(string password, string currentPassword, string salt);
    }
}
