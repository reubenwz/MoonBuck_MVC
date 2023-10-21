using Microsoft.EntityFrameworkCore;
using MoonBuck.Models;

namespace MoonBuck.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Slot> Slots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Chef", DisplayOrder= 1},
                new Role { Id = 2, Name = "Cashier", DisplayOrder = 2 },
                new Role { Id = 3, Name = "Waiter", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Slot>().HasData(
                new Slot
                {
                    Id = 1,
                    CafeName = "MoonBuck Toa Payoh",
                    StartTime = DateTime.Now.AddDays(1),
                    EndTime = DateTime.Now.AddDays(1.4),
                    IsFilled = false,
                    PayRate = 9,
                    RoleId = 1,
                },
                new Slot
                {
                    Id = 2,
                    CafeName = "MoonBuck Toa Payoh",
                    StartTime = DateTime.Now.AddDays(2),
                    EndTime = DateTime.Now.AddDays(2.4),
                    IsFilled = false,
                    PayRate = 9,
                    RoleId = 2
                },
                new Slot
                {
                    Id = 3,
                    CafeName = "MoonBuck Tampines",
                    StartTime = DateTime.Now.AddDays(2),
                    EndTime = DateTime.Now.AddDays(2.4),
                    IsFilled = false,
                    PayRate = 9,
                    RoleId = 2
                },
                new Slot
                {
                    Id = 4,
                    CafeName = "MoonBuck Hougang",
                    StartTime = DateTime.Now.AddDays(3),
                    EndTime = DateTime.Now.AddDays(3.4),
                    IsFilled = false,
                    PayRate = 9,
                    RoleId = 2
                }
                );
        }
    }
}
