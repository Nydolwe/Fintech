using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestApiFintech.Models
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<FintechContext>
    {
        public FintechContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FintechContext>();
            optionsBuilder.UseSqlServer("Data Source=blog.db");

            return new FintechContext(optionsBuilder.Options);
        }
    }
}
