using AutoMapper;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Queries.GetAllProducts;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Queries.GetProductById
{
    public class GetProductByIdHandler(IProductsRepository _productsRepo, ILogger<ProductsService> logger, IMapper mapper)
        : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting product with id{request.Id}");
            var product = await _productsRepo.GetById(request.Id);
            var productDto = mapper.Map<ProductDto?>(product);
            return productDto;
        }
    }
}
