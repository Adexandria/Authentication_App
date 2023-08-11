using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    public interface IAuthRepository
    {
        string GenerateAccessToken(Guid userId, string role);
    }
}
