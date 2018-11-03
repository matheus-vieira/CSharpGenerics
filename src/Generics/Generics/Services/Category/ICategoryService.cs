namespace Generics.Services.Category
{
    public interface ICategoryService : Generic.IGenericService<Models.Ecommerce.Category>
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.Ecommerce.Category>> GetAllAsync(Models.Filter.CategoryFilter filter);
    }
}
