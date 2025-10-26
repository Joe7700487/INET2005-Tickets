using AwesomeTickets.Data;
using AwesomeTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AwesomeTickets.Controllers
{
    [Authorize]
    public class ListingsController : Controller
    {
        private readonly AwesomeTicketsContext _context;

        public ListingsController(AwesomeTicketsContext context)
        {
            _context = context;
        }


        // GET: Listings/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListingId,ListingTitle,ListingDescription,ListingDate,ListingLocation,ListingOwner,CategoryId,FormFile")] Listing listing)
        {
            var date = DateTime.Now;
            listing.DateCreated = date;
            if (ModelState.IsValid)
            {

                if (listing.FormFile != null)
                {

                    string filename = date.ToString("HH-mm-ss-ffffff") + "_" + listing.FormFile.FileName;

                    listing.FileName = filename;

                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await listing.FormFile.CopyToAsync(fileStream);
                    }
                }

                _context.Add(listing);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", listing.CategoryId);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listing.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", listing.CategoryId);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListingId,ListingTitle,ListingDescription,ListingDate,ListingLocation,ListingOwner,CategoryId,FormFile")] Listing listing)
        {
            if (id != listing.ListingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingListing = await _context.Listing.AsNoTracking().FirstOrDefaultAsync(l => l.ListingId == id);

                    if (listing.FormFile != null)
                    {
                        var date = DateTime.Now;

                        string filename = date.ToString("HH-mm-ss-ffffff") + "_" + listing.FormFile.FileName;

                        listing.FileName = filename;

                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await listing.FormFile.CopyToAsync(fileStream);
                        }
                    }
                    else
                    {
                        listing.FormFile = existingListing.FormFile;
                        listing.FileName = existingListing.FileName;
                    }
                    listing.DateCreated = existingListing.DateCreated;
                    _context.Update(listing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingExists(listing.ListingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", listing.CategoryId);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listing
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.ListingId == id);
            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listing = await _context.Listing.FindAsync(id);
            if (listing != null)
            {
                _context.Listing.Remove(listing);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ListingExists(int id)
        {
            return _context.Listing.Any(e => e.ListingId == id);
        }
    }
}
