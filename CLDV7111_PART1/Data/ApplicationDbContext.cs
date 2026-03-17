using Microsoft.EntityFrameworkCore;
using CLDV7111_PART1.Models;

namespace CLDV7111_PART1.Data
{
    // ApplicationDbContext: central class for interacting with the database using Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        // Constructor: passes configuration options (like connection string) to the base DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // DbSet properties represent tables in the database
        public DbSet<Event> Event { get; set; }     // Table for Events
        public DbSet<Venue> Venue { get; set; }     // Table for Venues
        public DbSet<Booking> Booking { get; set; } // Table for Bookings

        // OnModelCreating: used to configure the model (tables, relationships, constraints)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly map each entity to its corresponding table
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Venue>().ToTable("Venue");
            modelBuilder.Entity<Booking>().ToTable("Booking");
        }
    }
}