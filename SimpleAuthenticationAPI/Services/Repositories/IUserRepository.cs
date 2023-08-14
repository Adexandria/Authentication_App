using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// Manages the CRUD operations of a user
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a new user to the existing database
        /// </summary>
        /// <param name="user">An object that includes details of a user</param>
        /// <returns>True if the object was persisted or false if it wasn't</returns>
        Task<bool> AddUser(User user);

        /// <summary>
        /// Check if user exists
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>True if user exists or false it it doesn't</returns>
        Task<bool> ExistsAsync(string email);

        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>A user if it's exists</returns>
        Task<User> GetUserByEmail(string email);

        Task<User> GetUserById(Guid userId);

        IEnumerable<User> GetUsersRoleType();
    }
}
