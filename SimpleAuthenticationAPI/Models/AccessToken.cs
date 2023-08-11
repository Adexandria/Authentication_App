using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAuthenticationAPI.Models
{
    public class AccessToken : BaseEntity
    {
        public AccessToken(string token)
        {
            Token = token;
        }

        public AccessToken SetUser(Guid userId)
        {
            UserId = userId;
            return this;
        }
        
        public string Token { get; set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
    }
}