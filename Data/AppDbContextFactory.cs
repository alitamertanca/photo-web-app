using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PhotoWebApp.Models;

namespace PhotoWebApp.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=PhotoWebApp.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
