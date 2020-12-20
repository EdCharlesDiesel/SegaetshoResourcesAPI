using System;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Entities;
using GloboTicket.Services.ShoppingBasket.Extensions;
using SegaetshoResources.Services.ShoppingBasket.Entities;
using SegaetshoResources.Services.ShoppingBasket.Extensions;

namespace SegaetshoResources.Services.ShoppingBasket.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient client;

        public EventCatalogService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Event>();
        }
    }
}
