using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generics.Services.Product
{
    public class ProductService : Generic.GenericService<Models.Ecommerce.Product>, IProductService
    {
        public ProductService(Data.ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Models.Ecommerce.Product>> GetAllAsync()
        {
            var query = DbSet
                .Include(p => p.Category)
                .Include(p => p.Supplier);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Models.Ecommerce.Product>> GetAllAsync(Models.Filter.ProductFilter filter)
        {
            var query = DbSet
                .Where(p => string.IsNullOrWhiteSpace(filter.Name) || p.Name.ToLower().Contains(filter.Name.ToLower()))
                .Include(p => p.Category)
                .Where(p => string.IsNullOrWhiteSpace(filter.Category) || p.Category.Name.ToLower().Contains(filter.Category.ToLower()))
                .Include(p => p.Supplier)
                .Where(p => string.IsNullOrWhiteSpace(filter.Supplier) || p.Supplier.Name.ToLower().Contains(filter.Supplier.ToLower()));
            return await query.ToListAsync();
        }
    }
}
