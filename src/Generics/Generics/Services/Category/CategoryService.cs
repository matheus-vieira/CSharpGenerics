using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generics.Services.Category
{
    public class CategoryService : Generic.GenericService<Models.Ecommerce.Category>, ICategoryService
    {
        public CategoryService(Data.ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Models.Ecommerce.Category>> GetAllAsync(Models.Filter.CategoryFilter filter)
        {
            var query = DbSet
                .Where(p => string.IsNullOrWhiteSpace(filter.Name) || p.Name.ToLower().Contains(filter.Name.ToLower()));
            return await query.ToListAsync();
        }
    }
}
