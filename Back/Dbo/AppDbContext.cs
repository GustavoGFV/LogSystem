using Microsoft.EntityFrameworkCore;
using Logger.Dto;

namespace Logger.Dbo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LogModel>();
        }

        public DbSet<LogModel>? Log { get; set; } 
    }
}
