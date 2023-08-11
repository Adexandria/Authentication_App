using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<bool> ExistsAsync(string email);
        Task<User> GetUserByEmail(string email);
    }
}
