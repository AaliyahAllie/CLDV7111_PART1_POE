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

        public IActionResult Index()
        {
            var events = _context.Events.Include(e => e.Venue).ToList();
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var ev = _context.Events.Include(e => e.Venue).FirstOrDefault(e => e.EventId == id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        public IActionResult Create()
        {
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        public IActionResult Edit(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();
            ViewBag.Venues = _context.Venues.ToList();
            return View(ev);
        }

        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        public IActionResult Delete(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();
            return View(ev);
        }

        [HttpPost, ActionName("Delete")]
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