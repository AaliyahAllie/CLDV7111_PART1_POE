using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CLDV7111_PART1.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Event
        public IActionResult Index()
        {
            var events = _context.Events.Include(e => e.Venue).ToList();
            return View(events);
        }

        // GET: Event/Details/5
        public IActionResult Details(int id)
        {
            var ev = _context.Events
                .Include(e => e.Venue)
                .FirstOrDefault(e => e.EventId == id);

            if (ev == null) return NotFound();
            return View(ev);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Venues = _context.Venues.ToList();
            return View(ev);
        }

        // GET: Event/Edit/5
        public IActionResult Edit(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();

            ViewBag.Venues = _context.Venues.ToList();
            return View(ev);
        }

        // POST: Event/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Venues = _context.Venues.ToList();
            return View(ev);
        }

        // GET: Event/Delete/5
        public IActionResult Delete(int id)
        {
            var ev = _context.Events
                .Include(e => e.Venue)
                .FirstOrDefault(e => e.EventId == id);

            if (ev == null) return NotFound();
            return View(ev); // shows confirmation screen
        }

        // POST: Event/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}