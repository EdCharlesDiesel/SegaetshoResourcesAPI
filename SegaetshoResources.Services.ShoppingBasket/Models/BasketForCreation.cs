using System;
using System.ComponentModel.DataAnnotations;

namespace SegaetshoResources.Services.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
