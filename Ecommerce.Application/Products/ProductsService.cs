using AutoMapper;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Products
{
    public class ProductsService(IProductsRepository _productsRepo, ILogger<ProductsService> logger, IMapper mapper) : IProductsService
    {
        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            logger.LogInformation("getting products");
            var products = await _productsRepo.GetAll();
            var poductDto = mapper.Map<IEnumerable<ProductDto>>(products);
            return poductDto;
        }

        public async Task<Guid> Create(CreateProductDto dto)
        {
            logger.LogInformation("Creating product");
            var product = mapper.Map<Product>(dto);
            return await _productsRepo.Create(product);
        }

        public async Task<ProductDto?> GetById(Guid id)
        {
            logger.LogInformation($"Getting product with id{id}");
            var product = await _productsRepo.GetById(id);
            var productDto = mapper.Map<ProductDto?>(product);
            return productDto;
        }
    }
}
