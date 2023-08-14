using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// This manages token creation
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Generates access token for a particular user
        /// </summary>
        /// <param name="userId">A user id</param>
        /// <param name="role">A user role</param>
        /// <returns>A access token</returns>
        string GenerateAccessToken(Guid userId, string role);
    }
}
