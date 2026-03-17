using CLDV7111_PART1.Data;
using CLDV7111_PART1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CLDV7111_PART1.Controllers
{
    // Controller responsible for handling CRUD operations for Events
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: injects the database context into the controller
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Event
        // Displays a list of all events
        public IActionResult Index()
        {
            // Query directly from Event table
            var events = _context.Event.ToList();
            return View(events);
        }

        // GET: Event/Details/5
        // Displays details of a single event by ID
        public IActionResult Details(int id)
        {
            var ev = _context.Event.FirstOrDefault(e => e.EventId == id);
            if (ev == null) return NotFound(); // Return 404 if event not found
            return View(ev);
        }

        // GET: Event/Create
        // Displays the form to create a new event
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // Handles form submission for creating a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                // Add new event to database
                _context.Event.Add(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to list of events
            }
            return View(ev); // Reload form if validation fails
        }

        // GET: Event/Edit/5
        // Displays the form to edit an existing event
        public IActionResult Edit(int id)
        {
            var ev = _context.Event.Find(id);
            if (ev == null) return NotFound(); // Return 404 if event not found
            return View(ev);
        }

        // POST: Event/Edit
        // Handles form submission for editing an existing event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event ev)
        {
            if (ModelState.IsValid)
            {
                // Update event in database
                _context.Event.Update(ev);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ev); // Reload form if validation fails
        }

        // GET: Event/Delete/5
        // Displays confirmation page for deleting an event
        public IActionResult Delete(int id)
        {
            var ev = _context.Event.FirstOrDefault(e => e.EventId == id);
            if (ev == null) return NotFound(); // Return 404 if event not found
            return View(ev); // Shows confirmation screen
        }

        // POST: Event/DeleteConfirmed/5
        // Handles deletion of an event after confirmation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ev = _context.Event.Find(id);
            if (ev != null)
            {
                _context.Event.Remove(ev);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}