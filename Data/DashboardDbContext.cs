using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class DashboardDbContext : DbContext
    {
        public DashboardDbContext(DbContextOptions<DashboardDbContext> options)
            : base(options) { }

        public DbSet<Equipment> Equipments { get; set; } = null!;
        public DbSet<Failure> Failures { get; set; } = null!;
    }
}
