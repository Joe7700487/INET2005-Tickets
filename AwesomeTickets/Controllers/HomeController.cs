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

            List <Event> events = new List<Event>();

            Event event1 = new Event();
            event1.EventId = 1;
            event1.EventTitle = "event title";
            event1.EventDate = new DateTime(2025, 9, 19, 13, 58, 0); // Sept 19, 2025 1:58pm;
            event1.DateCreated = DateTime.Now;
            events.Add(event1);

            Event event2 = new Event();
            event2.EventId = 2;
            event2.EventTitle = "event title 2";
            event2.EventDate = new DateTime(2026, 9, 19, 13, 58, 0); // Sept 19, 2025 1:58pm;
            event2.DateCreated = DateTime.Now;

            events.Add(event2);

            _logger.Log(LogLevel.Information, "Number of events: " + events.Count);


            return View(events);
        }

        public IActionResult EventDetails(int id)
        {
            int eventId = id;
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
