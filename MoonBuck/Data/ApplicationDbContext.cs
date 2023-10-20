using Microsoft.EntityFrameworkCore;
using MoonBuck.Models;

namespace MoonBuck.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Chef", DisplayOrder= 1},
                new Role { Id = 2, Name = "Cashier", DisplayOrder = 2 },
                new Role { Id = 3, Name = "Waiter", DisplayOrder = 3 }
                );
        }
    }
}
