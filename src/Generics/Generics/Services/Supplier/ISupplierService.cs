namespace Generics.Services.Supplier
{
    public interface ISupplierService : Generic.IGenericService<Models.Ecommerce.Supplier>
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.Ecommerce.Supplier>> GetAllAsync(Models.Filter.SupplierFilter filter);
    }
}
