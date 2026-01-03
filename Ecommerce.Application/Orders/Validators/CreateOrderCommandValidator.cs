using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Dtos;
using Ecommerce.Domain.Repositories;
using FluentValidation;

namespace Ecommerce.Application.Orders.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(IValidator<OrderDetailsDto> _detailValidator)
        {
            RuleFor(o=>o.OrderDate).NotEmpty().WithMessage("Order date is required.");
            RuleFor(o => o.OrderDetails).NotEmpty().WithMessage("order must have at least one detail");
            RuleForEach(o => o.OrderDetails).SetValidator(_detailValidator);
        }
    }
}
