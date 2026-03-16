using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CLDV7111_PART1.Models
{
    [Table("Booking")]
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int EventId { get; set; }

        [ValidateNever]
        public Event Event { get; set; }

        [Required]
        public int VenueId { get; set; }

        [ValidateNever]
        public Venue Venue { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
    }
}