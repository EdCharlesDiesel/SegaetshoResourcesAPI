using Microsoft.EntityFrameworkCore;
using SegaetshoResources.Services.EventCategory.DbContexts;
using SegaetshoResources.Services.EventCategory.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SegaetshoResources.Services.EventCategory.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public CategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }


        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _eventCatalogDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(string categoryId)
        {
            return await _eventCatalogDbContext.Categories.Where(x => x.CategoryId.ToString() == categoryId).FirstOrDefaultAsync();
        }
    }
}
