using System.Collections.Generic;
using System.Threading.Tasks;
using SegaetshoResources.Services.EventCategory.Entities;

namespace SegaetshoResources.Services.EventCategory.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}