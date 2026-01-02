using Ecommerce.Application.Products.Queries.GetAllProducts;
using Ecommerce.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoriesRepository categoriesRepository) : ControllerBase
    {
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoriesRepository.GetAll();
            return Ok(categories);
        }
    }
}
