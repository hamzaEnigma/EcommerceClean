using Ecommerce.Application.Products.Dtos;
using FluentValidation;

namespace Ecommerce.Application.Products.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(3).WithMessage("Product name must bet more than 3 caracters.");

            RuleFor(p=>p.PurchasePrice).NotEmpty().WithMessage("Purchase price is required.")
                .GreaterThan(0).WithMessage("Purchase price must be greater than zero.");

            RuleFor(p => p.SellPrice).NotEmpty().WithMessage("Sell price is required.")
            .GreaterThan(0).WithMessage("Sell price must be greater than zero.");
        }
    }
}
