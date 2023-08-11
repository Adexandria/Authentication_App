using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }

        //This is another way of establishing the relationship between models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(s => s.AccessToken)
                .WithOne(s => s.User)
                 .HasForeignKey<AccessToken>(s=>s.UserId)
                 .IsRequired();
        }
    }
}
