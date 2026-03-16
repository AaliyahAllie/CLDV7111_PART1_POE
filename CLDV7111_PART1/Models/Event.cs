using System;
using System.ComponentModel.DataAnnotations;

namespace CLDV7111_PART1.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        // New field for user input
        [Required]
        public string VenueName { get; set; }

       
    }
}