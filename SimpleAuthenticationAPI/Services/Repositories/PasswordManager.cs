﻿namespace SimpleAuthenticationAPI.Services.Repositories
{
    public class PasswordManager : IPasswordManager
    {
        public string HashPassword(string password, out string salt)
        {
            salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hash;
        }
        public bool VerifyPassword(string password, string currentPassword, string salt)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return currentPassword.Equals(hashedPassword);
        }
    }
}
