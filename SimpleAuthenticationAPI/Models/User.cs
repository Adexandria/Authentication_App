namespace SimpleAuthenticationAPI.Models
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string firstName, string lastName, string email,Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
        
        public User SetPassword(string passwordHash, string salt)
        {
            PasswordHash = passwordHash;
            Salt = salt;
            return this;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; protected set; }
        public string Salt { get; protected set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public AccessToken AccessToken { get; protected set; }
    }
}
