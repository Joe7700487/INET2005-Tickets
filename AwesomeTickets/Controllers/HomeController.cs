using AwesomeTickets.Data;
using AwesomeTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AwesomeTickets.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AwesomeTicketsContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(AwesomeTicketsContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string LocationSort { get; set; }
        public string OwnerSort { get; set; }
        public string CategorySort { get; set; }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TitleSort"]       = sortOrder == "title"      ? "title_desc"      : "title";
            ViewData["DateSort"]        = sortOrder == "date"       ? "date_desc"       : "date";
            ViewData["LocationSort"]    = sortOrder == "location"   ? "location_desc"   : "location";
            ViewData["OwnerSort"]       = sortOrder == "owner"      ? "owner_desc"      : "owner";
            ViewData["CategorySort"]    = sortOrder == "category"   ? "category_desc"   : "category";

            var listings =  _context.Listing.Include(l => l.Category).AsQueryable();
                //.OrderBy(l => l.ListingDate)
                //.ToListAsync());

            switch (sortOrder)
            {
                case "title":
                    listings = listings.OrderBy(l => l.ListingTitle);
                    break;
                case "title_desc":
                    listings = listings.OrderByDescending(l => l.ListingTitle);
                    break;

                case "date":
                    listings = listings.OrderBy(l => l.ListingDate);
                    break;
                case "date_desc":
                    listings = listings.OrderByDescending(l => l.ListingDate);
                    break;

                case "location":
                    listings = listings.OrderBy(l => l.ListingLocation);
                    break;
                case "location_desc":
                    listings = listings.OrderByDescending(l => l.ListingLocation);
                    break;

                case "owner":
                    listings = listings.OrderBy(l => l.ListingOwner);
                    break;
                case "owner_desc":
                    listings = listings.OrderByDescending(l => l.ListingOwner);
                    break;

                case "category":
                    listings = listings.OrderBy(l => l.Category.CategoryName);
                    break;
                case "category_desc":
                    listings = listings.OrderByDescending(l => l.Category.CategoryName);
                    break;
            }

            return View(await listings.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listing
                .FirstOrDefaultAsync(m => m.ListingId == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
