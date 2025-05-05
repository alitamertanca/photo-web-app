using Microsoft.EntityFrameworkCore;
using PhotoWebApp.Models;

namespace PhotoWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}