﻿namespace SimpleAuthenticationAPI.Services.Repositories
{
    public interface IPasswordManager
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string password, string currentPassword, string salt);
    }
}