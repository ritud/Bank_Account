using Microsoft.EntityFrameworkCore;
 
namespace Bank_Account.Models
{
    public class UserContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> user { get; set; }
        public DbSet<Transaction> transactions { get; set; }
    }
}