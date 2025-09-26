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
            //List<Listing> listings = new List<Listing>();
            //Listing listing1 = new Listing();
            //listing1.ListingId = 1;
            //listing1.ListingTitle = "show title";
            //listing1.ListingDate = new DateTime(2025, 9, 19, 13, 58, 0); // Sept 19, 2025 1:58pm;
            //listing1.DateCreated = DateTime.Now;
            //listings.Add(listing1);
            //Listing listing2 = new Listing();
            //listing2.ListingId = 2;
            //listing2.ListingTitle = "show title 2";
            //listing2.ListingDate = new DateTime(2026, 9, 19, 13, 58, 0); // Sept 19, 2025 1:58pm;
            //listing2.DateCreated = DateTime.Now;
            //listings.Add(listing2);
            //_logger.Log(LogLevel.Information, "Number of shows: " + listings.Count);
            //return View(listings);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
