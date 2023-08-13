using SimpleAuthenticationAPI.Models;
using SimpleAuthenticationAPI.Services.Repositories;

namespace SimpleAuthenticationAPI.Services
{
    public static class SeedDatabase
    {
        public static async Task IsSeeded(IServiceProvider provider,DefaultConfiguration defaultConfig)
        {
            var userRepository = provider.GetService<IUserRepository>() ?? throw new NullReferenceException("Unregistered service");
            
            var passwordManager = provider.GetService<IPasswordManager>()?? throw new NullReferenceException("Unregistered service");
            
            var isExist = await userRepository.ExistsAsync(defaultConfig.Email);
            
            if (isExist)
                return;
            
            var hashedPassword = passwordManager.HashPassword(defaultConfig.Password, out string salt);
            
            var user = new User(defaultConfig.FirstName, defaultConfig.LastName, defaultConfig.Email, Role.Admin)
                .SetPassword(hashedPassword,salt);
            
            await userRepository.AddUser(user);
        }
    }
}
