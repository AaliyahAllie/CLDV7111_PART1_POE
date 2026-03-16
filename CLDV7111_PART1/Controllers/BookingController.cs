using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CLDV7111_PART1.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public IActionResult Index()
        {
            var bookings = _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .ToList();
            return View(bookings);
        }

        // GET: Booking/Details/5
        public IActionResult Details(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefault(b => b.BookingId == id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewBag.Events = _context.Events.ToList();
            ViewBag.Venues = _context.Venues.ToList();
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Events = _context.Events.ToList();
            ViewBag.Venues = _context.Venues.ToList();
            return View(booking);
        }

        // GET: Booking/Delete/5
        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefault(b => b.BookingId == id);

            if (booking == null) return NotFound();
            return View(booking); // shows confirmation screen
        }

        // POST: Booking/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}