using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksApp.Data;
using TasksApp.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TasksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var tasks = await _context.TaskItems.ToListAsync();
            var categories = await _context.Categories.ToListAsync();

            var recentTasks = tasks
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .Select(t => new
                {
                    id = t.Id,
                    title = t.Title,
                    description = t.Description,
                    isCompleted = t.IsCompleted,
                    priority = t.Priority,
                    dueDate = t.DueDate?.ToString("MMM dd, yyyy"),
                    category = t.CategoryId.HasValue ? categories.FirstOrDefault(c => c.Id == t.CategoryId)?.Name : null
                });

            return Json(new
            {
                totalTasks = tasks.Count,
                completedTasks = tasks.Count(t => t.IsCompleted),
                pendingTasks = tasks.Count(t => !t.IsCompleted),
                totalCategories = categories.Count,
                recentTasks = recentTasks
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}