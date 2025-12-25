using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductsRepository _productsRepo, ILogger<CreateProductCommandHandler> logger, IMapper mapper)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating product");
            var product = mapper.Map<Product>(request);
            return await _productsRepo.Create(product);
        }
    }
}
