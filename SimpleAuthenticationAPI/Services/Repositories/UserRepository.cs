using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    /// <summary>
    /// Manages the CRUD operations of a user
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="db">An instance to perform CRUD operations from the db</param>
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Adds a new user to the existing database
        /// </summary>
        /// <param name="user">An object that includes details of a user</param>
        /// <returns>True if the object was persisted or false if it wasn't</returns>
        public async Task<bool> AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            int rowInserted = await _db.SaveChangesAsync();
            if (rowInserted == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Check if user exists
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>True if user exists or false it it doesn't</returns>
        public async Task<bool> ExistsAsync(string email)
        {
            return await _db.Users.AnyAsync(s => s.Email == email);
        }

        /// <summary>
        /// Gets a user by email
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>A user if it's exists</returns>
        public async Task<User> GetUserByEmail(string email)
        {
            return await _db.Users.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _db.Users.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.Id == userId);
        }

        public IEnumerable<User> GetUsersRoleType()
        {
            return _db.Users.AsNoTracking().Where(s=>s.Role == Role.User).ToList();
        }

        private readonly AppDbContext _db;
    }
}
