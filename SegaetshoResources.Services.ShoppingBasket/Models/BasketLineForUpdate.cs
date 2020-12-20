using System.ComponentModel.DataAnnotations;

namespace SegaetshoResources.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}
