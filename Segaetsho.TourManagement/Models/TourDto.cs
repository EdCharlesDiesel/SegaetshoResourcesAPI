using System;

namespace SegaetshoResources.Services.TourManagement.Models
{
    public class TourDto 
    {
        public Guid TourId { get; set; }
        public string Band { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
