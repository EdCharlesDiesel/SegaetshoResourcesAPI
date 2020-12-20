using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SegaetshoResources.API.Models;

namespace SegaetshoResources.API.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid);
        Task<Event> GetEvent(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}
