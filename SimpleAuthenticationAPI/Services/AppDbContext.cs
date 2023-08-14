using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services
{
    /// <summary>
    /// This includes configuration that is used to perform CRUD operations.
    /// This is also used to connect to that database.
    /// </summary>
    public class AppDbContext: DbContext
    {
        /// <summary>
        /// A Constructor
        /// </summary>
        /// <param name="options">This is used to create an instance of the db context</param>
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
           
        }
        
        /// <summary>
        /// This initialises an instance of the model 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// This is used to define the relationship of the models. 
        /// </summary>
        /// <param name="modelBuilder">An object to define the models</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
