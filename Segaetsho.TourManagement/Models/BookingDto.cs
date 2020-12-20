using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.Services.TourManagement.Models
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public string Hotel { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public bool Coupon { get; set; }
        public int Rooms { get; set; }
        public DateTimeOffset CheckIn { get; set; }
        public DateTimeOffset CheckOut { get; set; }
    }
}
