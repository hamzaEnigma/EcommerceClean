using AutoMapper;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler(IProductsRepository _productsRepo, ILogger<ProductsService> logger, IMapper mapper)
        : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("getting products");
            var products = await _productsRepo.GetAll();
            var poductDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return poductDto;
        }
    }
}
