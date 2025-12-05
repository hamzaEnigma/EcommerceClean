using Ecommerce.Application.Products.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto?> GetById(Guid id);
        Task<Guid> Create(CreateProductDto product);
    }
}
