using Generics.Data;
using Generics.Models.Ecommerce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generics.Controllers
{
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(
            Services.Generic.IGenericService<Category> service
            )
            : base(service)
        {
        }
    }
}
