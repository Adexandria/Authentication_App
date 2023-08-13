namespace SimpleAuthenticationAPI.Models.DTOs
{
    public class UserDTO
    {
        public UserDTO(string firstName, string lastName, string accessToken)
        {
            Name = $"{firstName} {lastName}";
            AccessToken = accessToken;
        }
        public string Name { get; set; }
        public string AccessToken { get; set; }
    }
}
