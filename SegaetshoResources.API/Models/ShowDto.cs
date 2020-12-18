using System;

namespace SegaetshoResources.API.Models
{
    public class ShowDto  
    {
        public Guid ShowId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
 