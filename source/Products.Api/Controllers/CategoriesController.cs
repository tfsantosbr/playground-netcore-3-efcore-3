using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data.SqlServer.Context;
using Products.Domain.Categories;
using Products.Domain.Categories.Models;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DbSet<Category> _categories;

        public CategoriesController(ProductsContext context)
        {
            _categories = context.Categories;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categories
                .Select(c => new CategoryItem { Id = c.Id, Title = c.Title })
                .ToListAsync();

            return Ok(categories);
        }
    }
}

