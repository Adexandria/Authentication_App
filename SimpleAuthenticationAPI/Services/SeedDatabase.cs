using SimpleAuthenticationAPI.Models;
using SimpleAuthenticationAPI.Services.Repositories;

namespace SimpleAuthenticationAPI.Services
{
    /// <summary>
    /// Creates and seed database if not seeded
    /// </summary>
    public static class SeedDatabase
    {
        /// <summary>
        /// Seed configuration of the admin
        /// </summary>
        /// <param name="provider">In builder provider to get registered services</param>
        /// <param name="defaultConfig">Includes details to seed</param>
        /// <exception cref="NullReferenceException">If the services are not registered</exception>
        public static async Task SeedDefaultConfiguration(IServiceProvider provider,DefaultConfiguration defaultConfig)
        {
            var dbContext = provider.GetService<AppDbContext>() ?? throw new NullReferenceException("Unregistered service");
            
            var userRepository = provider.GetService<IUserRepository>() ?? throw new NullReferenceException("Unregistered service");
            
            var passwordManager = provider.GetService<IPasswordManager>()?? throw new NullReferenceException("Unregistered service");
            
            dbContext.Database.EnsureCreated();

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
