using Ecommerce.Application.Products;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsService _productsService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productsService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productDto = await _productsService.GetById(id);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            var validator = new ProductValidator();
            ValidationResult result = await validator.ValidateAsync(createProductDto);
            if (result.IsValid)
            {
                var id = await _productsService.Create(createProductDto);
                return Ok(id);
            }
            return BadRequest(result.Errors);
        }
    }
}
