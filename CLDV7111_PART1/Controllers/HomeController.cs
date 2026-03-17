using System.Diagnostics;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLDV7111_PART1.Controllers
{
    // Controller responsible for handling general site navigation and static pages
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor: injects a logger instance into the controller
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Home/Index
        // Displays the home page of the application
        public IActionResult Index()
        {
            return View();
        }

        // GET: Home/Privacy
        // Displays the privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Home/Error
        // Displays an error page with request details
        // ResponseCache attribute ensures the error page is never cached
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create an ErrorViewModel with the current request ID
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}