using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CLDV7111_PART1.Models
{
    // Booking entity mapped to the "Booking" table in the database
    [Table("Booking")]
    public class Booking
    {
        // Primary key for the Booking table
        public int BookingId { get; set; }

        // Foreign key referencing the Event table
        [Required] // Ensures EventId must be provided
        public int EventId { get; set; }

        // Navigation property for the related Event
        // ValidateNever prevents validation on this property during model binding
        [ValidateNever]
        public Event Event { get; set; }

        // Foreign key referencing the Venue table
        [Required] // Ensures VenueId must be provided
        public int VenueId { get; set; }

        // Navigation property for the related Venue
        [ValidateNever]
        public Venue Venue { get; set; }

        // Date of the booking
        [Required] // Ensures BookingDate must be provided
        [DataType(DataType.Date)] // Specifies that only the date (not time) is stored/displayed
        public DateTime BookingDate { get; set; }
    }
}