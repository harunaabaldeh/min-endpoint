using Microsoft.EntityFrameworkCore;
using MinimalApiEndpoint.Models;

namespace MinimalApiEndpoint.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}