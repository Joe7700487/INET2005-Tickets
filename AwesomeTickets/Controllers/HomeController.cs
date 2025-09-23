using System.Diagnostics;
using AwesomeTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventDetails()
        {
            return View();
        }

        public IActionResult AddEvent()
        {
            return View();
        }

        public IActionResult UpdateEvent()
        {
            return View();
        }

        public IActionResult DeleteEvent()
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
