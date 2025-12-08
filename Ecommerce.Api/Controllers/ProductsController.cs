using Ecommerce.Application.Products;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Queries.GetAllProducts;
using Ecommerce.Application.Products.Queries.GetProductById;
using Ecommerce.Application.Products.Validators;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductsService _productsService, IMediator _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllProductsQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery(id));
            if (productDto == null)
                return NotFound();
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
