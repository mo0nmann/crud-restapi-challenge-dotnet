// Using directives
using Microsoft.EntityFrameworkCore;
using crud_restapi_challenge.Entities; 

namespace crud_restapi_challenge
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");
            });
        }

        public DbSet<Item> Items { get; set; } 
    }
}
