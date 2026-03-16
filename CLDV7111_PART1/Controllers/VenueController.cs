using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CLDV7111_PART1.Controllers
{
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Venue
        public IActionResult Index()
        {
            return View(_context.Venues.ToList());
        }

        // GET: Venue/Details/5
        public IActionResult Details(int id)
        {
            var venue = _context.Venues.FirstOrDefault(v => v.VenueId == id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        // GET: Venue/Create
        public IActionResult Create() => View();

        // POST: Venue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        // GET: Venue/Edit/5
        public IActionResult Edit(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        // POST: Venue/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Update(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        // GET: Venue/Delete/5
        public IActionResult Delete(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue == null) return NotFound();
            return View(venue); // shows confirmation screen
        }

        // POST: Venue/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue != null)
            {
                _context.Venues.Remove(venue);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}