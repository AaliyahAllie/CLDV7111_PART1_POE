using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLDV7111_PART1.Models
{
    [Table("Booking")]   
    public class Booking
    {
        public int BookingId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public DateTime BookingDate { get; set; }
    }
}