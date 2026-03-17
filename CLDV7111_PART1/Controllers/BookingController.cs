using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace CLDV7111_PART1.Controllers
{
    // Controller responsible for handling CRUD operations for Bookings
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: injects the database context into the controller
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking
        // Displays a list of all bookings, including related Event and Venue data
        public IActionResult Index()
        {
            var bookings = _context.Booking
                .Include(b => b.Event)   // Load related Event entity
                .Include(b => b.Venue)   // Load related Venue entity
                .ToList();

            return View(bookings);
        }

        // GET: Booking/Details/5
        // Displays details of a single booking by ID
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound(); // Return 404 if no ID provided

            var booking = _context.Booking
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .FirstOrDefault(m => m.BookingId == id);

            if (booking == null)
                return NotFound(); // Return 404 if booking not found

            return View(booking);
        }

        // GET: Booking/Create
        // Displays the form to create a new booking
        public IActionResult Create()
        {
            // Pass lists of Events and Venues to the view for dropdowns
            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();
            return View();
        }

        // POST: Booking/Create
        // Handles form submission for creating a new booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            // Validate the model before saving
            if (!ModelState.IsValid)
            {
                // Collect validation errors and return them as plain text
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Content("Model invalid: " + string.Join(" | ", errors));
            }

            // Add booking to database and save changes
            _context.Booking.Add(booking);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); // Redirect to list of bookings
        }

        // GET: Booking/Edit/5
        // Displays the form to edit an existing booking
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = _context.Booking.Find(id);

            if (booking == null)
                return NotFound();

            // Pass lists of Events and Venues to the view for dropdowns
            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();

            return View(booking);
        }

        // POST: Booking/Edit/5
        // Handles form submission for editing an existing booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Booking booking)
        {
            if (id != booking.BookingId)
                return NotFound(); // Ensure the ID matches the booking being edited

            if (ModelState.IsValid)
            {
                // Update booking in database
                _context.Update(booking);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // Reload dropdowns if validation fails
            ViewBag.Events = _context.Event.ToList();
            ViewBag.Venues = _context.Venue.ToList();

            return View(booking);
        }

        // GET: Booking/Delete/5
        // Displays confirmation page for deleting a booking
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
        // Handles deletion of a booking after confirmation
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