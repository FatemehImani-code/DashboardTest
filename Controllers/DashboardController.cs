using Dashboard.Data;
using Dashboard.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardDbContext _context;

        public DashboardController(DashboardDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get all data grouped by Equipment
            var dashboardData = _context.Failures
                .Include(f => f.Equipment)
                .GroupBy(f => f.Equipment!.Name)
                .Select(g => new DashboardViewModel
                {
                    Equipment = g.Key,
                    TotalFailures = g.Count(),
                    TotalDowntime = g.Sum(x => x.DowntimeHours),
                    TotalCost = g.Sum(x => x.Cost)
                })
                .ToList();

            return View(dashboardData);
        }
    }
}
