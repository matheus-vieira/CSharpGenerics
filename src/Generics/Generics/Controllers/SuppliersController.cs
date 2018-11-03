namespace Generics.Controllers
{
    public class SuppliersController : GenericController<Models.Ecommerce.Supplier, long?>
    {
        private readonly Services.Supplier.ISupplierService _service;

        public SuppliersController(
            Services.Supplier.ISupplierService service
            )
            : base(service)
        {
            _service = service;
        }

        // Probably this coud be refactor to the generic controller
        // But for example I'll keep here
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Filter(Models.Filter.SupplierFilter filter)
        {
            filter.AddViewData(ViewData);
            var list = await _service.GetAllAsync(filter);
            return View(nameof(Index), list);
        }
    }
}
