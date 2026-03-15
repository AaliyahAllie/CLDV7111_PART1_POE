using System.ComponentModel.DataAnnotations.Schema;

namespace CLDV7111_PART1.Models
{
    [Table("Venue")]  
    public class Venue
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; }
    }
}