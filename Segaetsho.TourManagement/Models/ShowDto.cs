using System;

namespace SegaetshoResources.Services.TourManagement.Models
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
 