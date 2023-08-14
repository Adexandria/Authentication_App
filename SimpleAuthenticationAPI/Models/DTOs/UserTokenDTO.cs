namespace SimpleAuthenticationAPI.Models.DTOs
{
    /// <summary>
    /// An object used to display user data with access token
    /// </summary>
    public class UserTokenDTO
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="firstName">First name of the user</param>
        /// <param name="lastName">Last name of the user</param>
        /// <param name="accessToken">Access token</param>
        public UserTokenDTO(string firstName, string lastName, string accessToken)
        {
            Name = $"{firstName} {lastName}";
            AccessToken = accessToken;
        }

        /// <summary>
        /// First name and last name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Access token generated for the user
        /// </summary>
        public string AccessToken { get; set; }
    }
}
