using Ecommerce.Application.Orders.Dtos;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Orders.Validators
{
    public class CreateOrderDetailValidator : AbstractValidator<OrderDetailsDto>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateOrderDetailValidator(IProductsRepository _productsRepository)
        {
            RuleFor(x => x.ProductId)
                .MustAsync(async (id, cancellation) =>
                {
                    var product = await _productsRepository.GetById(id);
                    return product != null;
                })
                .WithMessage(p=> $"Produit avec id: {p.ProductId} etre existant dans la base de donnée ");

            RuleFor(x => x.Quantity).InclusiveBetween((short)1,short.MaxValue).WithMessage("Quantity must be at least 1.");
        }

        public  bool checkProduct(Guid productId)
        {
            var product =  _productsRepository.GetById(productId).Result;
            return product != null;
        }
    }
}
