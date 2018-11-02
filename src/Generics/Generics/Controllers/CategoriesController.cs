using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Generics.Controllers
{
    public class CategoriesController : GenericController<Models.Ecommerce.Category, long?>
    {
        private readonly Services.Category.ICategoryService _service;

        public CategoriesController(Services.Category.ICategoryService service)
            : base(service)
        {
            _service = service;
        }

        // Probably this coud be refactor to the generic controller
        // But for example I'll keep here
        public async Task<IActionResult> Filter(string name)
        {
            var list = await _service.GetAllAsync(name);
            ViewData["FilterName"] = name;
            return View(nameof(Index), list);
        }
    }
}
