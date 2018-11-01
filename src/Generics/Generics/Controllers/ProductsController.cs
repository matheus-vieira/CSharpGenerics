namespace Generics.Controllers
{
    public class ProductsController : GenericController<Models.Ecommerce.Product>
    {
        private readonly Services.Generic.IGenericService<Models.Ecommerce.Category> _categoryService;
        private readonly Services.Generic.IGenericService<Models.Ecommerce.Supplier> _supplierService;

        public ProductsController(
            Services.Generic.IGenericService<Models.Ecommerce.Product> service,
            Services.Generic.IGenericService<Models.Ecommerce.Category> categoryService,
            Services.Generic.IGenericService<Models.Ecommerce.Supplier> supplierService
            )
            : base(service)
        {
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        protected override async System.Threading.Tasks.Task<object> AddViewDataAsync(
            Models.Ecommerce.Product resource = null
            )
        {
            ViewData["CategoryId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                await _categoryService.GetAllAsync(),
                nameof(Models.Ecommerce.Product.CategoryId),
                nameof(Models.Ecommerce.Product.Name),
                resource?.CategoryId);
            ViewData["SupplierId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                await _supplierService.GetAllAsync(),
                nameof(Models.Ecommerce.Supplier.SupplierId),
                nameof(Models.Ecommerce.Supplier.Name),
                resource?.SupplierId);

            return base.AddViewDataAsync(resource);
        }
    }
}
