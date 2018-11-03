using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Generics.Services.Supplier
{
    public class SupplierService : Generic.GenericService<Models.Ecommerce.Supplier>, ISupplierService
    {
        public SupplierService(Data.ApplicationDbContext context)
            : base(context)
        {
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.Ecommerce.Supplier>> GetAllAsync(Models.Filter.SupplierFilter filter)
        {
            var query = DbSet
                .Where(p =>
                (string.IsNullOrWhiteSpace(filter.Name) || p.Name.ToLower().Contains(filter.Name.ToLower())));
            return await query.ToListAsync();
        }
    }
}
