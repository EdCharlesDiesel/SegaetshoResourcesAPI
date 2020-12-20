using System;
using System.ComponentModel.DataAnnotations;

namespace SegaetshoResources.API.Models
{
    public class BasketForCreation
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
