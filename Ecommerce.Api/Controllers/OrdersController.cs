using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Validators;
using Ecommerce.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator _mediator, IValidator<CreateOrderCommand> _validator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {

            var validationOrderResult = await _validator.ValidateAsync(command);
            if (!validationOrderResult.IsValid)
            {
                return BadRequest(validationOrderResult.Errors);
            }
            
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }
    }
}
