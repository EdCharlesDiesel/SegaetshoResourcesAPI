using SegaetshoResources.Services.EventCategory.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SegaetshoResources.Services.EventCategory.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetEvents(Guid categoryId);
        Task<Event> GetEventById(Guid eventId);
    }
}
