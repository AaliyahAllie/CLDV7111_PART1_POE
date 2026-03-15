using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(_context.Venues.ToList());
        }

        public IActionResult Details(int id)
        {
            var venue = _context.Venues.FirstOrDefault(v => v.VenueId == id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        public IActionResult Create() => View();

        [HttpPost]
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

        public IActionResult Edit(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost]
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

        public IActionResult Delete(int id)
        {
            var venue = _context.Venues.Find(id);
            if (venue == null) return NotFound();
            return View(venue);
        }

        [HttpPost, ActionName("Delete")]
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