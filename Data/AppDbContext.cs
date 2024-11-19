using Microsoft.EntityFrameworkCore;
using TodoAspNetAPI.Models;

namespace TodoAspNetAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<User> Users { get; set; }
    }
}