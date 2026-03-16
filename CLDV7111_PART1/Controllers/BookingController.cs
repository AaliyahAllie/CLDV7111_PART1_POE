using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

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
            var bookings = _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .ToList();

            return View(bookings);
        }

        // GET: Booking/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefault(m => m.BookingId == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Content("Model invalid: " + string.Join(" | ", errors));
            }

            _context.Booking.Add(booking);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Booking/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Booking.Find(id);

            if (booking == null)
                return NotFound();

            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();

            return View(booking);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Booking booking)
        {
            if (id != booking.BookingId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(booking);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();

            return View(booking);
        }

        // GET: Booking/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefault(m => m.BookingId == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _context.Booking.Find(id);

            if (booking != null)
            {
                _context.Booking.Remove(booking);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}