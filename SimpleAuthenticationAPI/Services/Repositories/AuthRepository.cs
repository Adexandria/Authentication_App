using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public AuthRepository(IConfiguration _configuration)
        {
            secretKey = _configuration["Jwt"];
        }
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

        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private readonly string secretKey;
    }
}
