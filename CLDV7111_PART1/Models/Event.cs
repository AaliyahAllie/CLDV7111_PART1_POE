using System;
using System.ComponentModel.DataAnnotations;

namespace CLDV7111_PART1.Models
{
    // Event entity representing an event in the system
    public class Event
    {
        // Primary key for the Event table
        public int EventId { get; set; }

        // Name of the event (required field)
        [Required]
        public string EventName { get; set; }

        // Date of the event (required field)
        [Required]
        public DateTime EventDate { get; set; }

        // Optional description providing more details about the event
        public string Description { get; set; }

        // New field for user input: venue name associated with the event
        [Required]
        public string VenueName { get; set; }
    }
}