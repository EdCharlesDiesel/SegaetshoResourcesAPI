using System;
using System.ComponentModel.DataAnnotations;

namespace SegaetshoResources.API.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public Guid LineId { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}
