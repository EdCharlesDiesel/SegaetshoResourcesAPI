using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegaetshoResources.API.Entities
{
    [Table("Bookings")]
    public class Booking: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }    

        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

        public int Adult { get; set; }

        public int Children { get; set; }

        public bool Coupon { get; set; }

        public int Rooms { get; set; }

        [Required]
        public DateTimeOffset CheckIn { get; set; }

        [Required]
        public DateTimeOffset CheckOut { get; set; }

    }
}
