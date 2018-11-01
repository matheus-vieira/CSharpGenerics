using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generics.Models.Ecommerce;
using Microsoft.EntityFrameworkCore;

namespace Generics.Services.Product
{
    public class ProductService : Generic.GenericService<Models.Ecommerce.Product>
    {
        public ProductService(Data.ApplicationDbContext context)
            : base(context)
        {
        }

        public async override Task<IEnumerable<Models.Ecommerce.Product>> GetAllAsync()
        {
            var query = DbSet
                .Include(p => p.Category)
                .Include(p => p.Supplier);
            return await query.ToListAsync();
        }
    }
}
