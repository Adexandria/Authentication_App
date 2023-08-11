using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<bool> AddUser(User user)
        {
            await db.Users.AddAsync(user);
            int rowInserted = await db.SaveChangesAsync();
            if (rowInserted == 0)
                return false;
            return true;
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await db.Users.AnyAsync(s => s.Email == email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.Users.
                AsNoTracking().
                FirstOrDefaultAsync(s => s.Email == email);
        }

        private AppDbContext db;
    }
}
