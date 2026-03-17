using System.ComponentModel.DataAnnotations.Schema;

namespace CLDV7111_PART1.Models
{
    // Venue entity mapped to the "Venue" table in the database
    [Table("Venue")]
    public class Venue
    {
        // Primary key for the Venue table
        public int VenueId { get; set; }

        // Name of the venue (e.g., "Conference Hall A")
        public string VenueName { get; set; }

        // Location of the venue (e.g., city, address, or region)
        public string Location { get; set; }

        // Maximum capacity of the venue (number of people it can hold)
        public int Capacity { get; set; }

        // Optional field: URL to an image representing the venue
        public string ImageUrl { get; set; }
    }
}