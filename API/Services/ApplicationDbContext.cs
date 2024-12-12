using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Households> households { get; set; }
        public DbSet<Resident> residents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasKey(a => a.adminID);
            modelBuilder.Entity<Households>().HasKey(h => h.HouseholdID);
            modelBuilder.Entity<Resident>().HasKey(r => r.residentID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
