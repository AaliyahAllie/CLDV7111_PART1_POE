using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CLDV7111_PART1.Controllers
{
    // Controller responsible for handling CRUD operations for Venues
    public class VenueController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: injects the database context into the controller
        public VenueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Venue
        // Displays a list of all venues
        public IActionResult Index()
        {
            return View(_context.Venue.ToList());
        }

        // GET: Venue/Details/5
        // Displays details of a single venue by ID
        public IActionResult Details(int id)
        {
            var venue = _context.Venue.FirstOrDefault(v => v.VenueId == id);
            if (venue == null) return NotFound(); // Return 404 if venue not found
            return View(venue);
        }

        // GET: Venue/Create
        // Displays the form to create a new venue
        public IActionResult Create() => View();

        // POST: Venue/Create
        // Handles form submission for creating a new venue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                // Add new venue to database
                _context.Venue.Add(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to list of venues
            }
            return View(venue); // Reload form if validation fails
        }

        // GET: Venue/Edit/5
        // Displays the form to edit an existing venue
        public IActionResult Edit(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue == null) return NotFound(); // Return 404 if venue not found
            return View(venue);
        }

        // POST: Venue/Edit
        // Handles form submission for editing an existing venue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                // Update venue in database
                _context.Venue.Update(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venue); // Reload form if validation fails
        }

        // GET: Venue/Delete/5
        // Displays confirmation page for deleting a venue
        public IActionResult Delete(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue == null) return NotFound(); // Return 404 if venue not found
            return View(venue); // Shows confirmation screen
        }

        // POST: Venue/DeleteConfirmed/5
        // Handles deletion of a venue after confirmation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var venue = _context.Venue.Find(id);
            if (venue != null)
            {
                _context.Venue.Remove(venue);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}