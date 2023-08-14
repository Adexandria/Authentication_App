using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// This manages token creation
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="_configuration">An object used to read app settings</param>
        public AuthRepository(IConfiguration _configuration)
        {
            secretKey = _configuration["Jwt"] ?? throw new NullReferenceException("Token Secret can not be empty");
        }

        /// <summary>
        /// Generates access token for a particular user
        /// </summary>
        /// <param name="userId">A user id</param>
        /// <param name="role">A user role</param>
        /// <returns>A access token</returns>
        public string GenerateAccessToken(Guid userId, string role)
        {
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>()
                {
                    { "id", userId.ToString() },
                    { ClaimTypes.Role, role }
                },
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        /// <summary>
        /// Generate the token security key
        /// </summary>
        /// <returns></returns>
        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private readonly string secretKey;
    }
}
