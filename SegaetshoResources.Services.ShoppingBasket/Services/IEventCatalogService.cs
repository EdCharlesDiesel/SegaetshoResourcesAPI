using SegaetshoResources.Services.ShoppingBasket.Entities;
using System;
using System.Threading.Tasks;


namespace SegaetshoResources.Services.ShoppingBasket.Services
{
    public interface IEventCatalogService
    {
        Task<Event> GetEvent(Guid id);
    }
}