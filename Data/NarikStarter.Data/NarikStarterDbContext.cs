using NarikStarter.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace NarikStarter.Data
{
    public partial class NarikStarterDbContext : DbContext
    {
        public NarikStarterDbContext()
        {
            
        }
        public NarikStarterDbContext( DbContextOptions options):base(options)
        {

        }


        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserAccountRole> UserAccountRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
