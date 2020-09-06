using Microsoft.EntityFrameworkCore;

namespace TestApiFintech.Models
{
    public class FintechContext : DbContext
    {
        
        public FintechContext(DbContextOptions<FintechContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<AccountRoutings> AccountRoutings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
