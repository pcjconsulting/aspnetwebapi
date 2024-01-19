using Microsoft.EntityFrameworkCore;

namespace aspnetwebapi.Models
{
    public class UserAccountContext : DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options)
            : base(options)
        { }

        public DbSet<UserAccount> UserAccounts { get; set; } = null!;
    }
}

