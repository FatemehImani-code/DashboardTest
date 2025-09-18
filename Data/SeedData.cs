using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DashboardDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<DashboardDbContext>>());

            if (context.Equipments.Any())
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            var eq1 = new Equipment { Name = "Compressor A", Department = "Utilities" };
            var eq2 = new Equipment { Name = "Pump B", Department = "Production" };
            var eq3 = new Equipment { Name = "Boiler C", Department = "Utilities" };

            context.Equipments.AddRange(eq1, eq2, eq3);

            context.Failures.AddRange(
                new Failure { Equipment = eq1, Cost = 1200, DowntimeHours = 4, FailureDate = DateTime.Today.AddDays(-10) },
                new Failure { Equipment = eq1, Cost = 900, DowntimeHours = 3, FailureDate = DateTime.Today.AddDays(-5) },
                new Failure { Equipment = eq2, Cost = 2500, DowntimeHours = 8, FailureDate = DateTime.Today.AddDays(-7) },
                new Failure { Equipment = eq3, Cost = 300, DowntimeHours = 1, FailureDate = DateTime.Today.AddDays(-2) }
            );

            context.SaveChanges();
            Console.WriteLine("Seed data completed successfully.");
        }
    }
}
