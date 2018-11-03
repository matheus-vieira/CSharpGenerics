namespace Generics.Services.Product
{
    public interface IProductService : Generic.IGenericService<Models.Ecommerce.Product>
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.Ecommerce.Product>> GetAllAsync(Models.Filter.ProductFilter filter);
    }
}