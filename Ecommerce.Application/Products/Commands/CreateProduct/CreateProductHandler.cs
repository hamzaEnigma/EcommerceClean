using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateProductHandler(IProductsRepository _productsRepo, ILogger<ProductsService> logger, IMapper mapper)
        : IRequestHandler<CreateProductQuery, Guid>
    {
        public async Task<Guid> Handle(CreateProductQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating product");
            var product = mapper.Map<Product>(request);
            return await _productsRepo.Create(product);
        }
    }
}
