using Microsoft.EntityFrameworkCore;
using CLDV7111_PART1.Models;

namespace CLDV7111_PART1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Event> Event { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Venue>().ToTable("Venue");
            modelBuilder.Entity<Booking>().ToTable("Booking");
        }
    }
}