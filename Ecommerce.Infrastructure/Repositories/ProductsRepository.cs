using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductsRepository(EcomerceContext _dbContext) : IProductsRepository
    {
        public async Task<Guid> Create(Product product)
        {
            _dbContext.Add(product);
            await _dbContext.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.Include(temp => temp.Category).ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _dbContext.Products.Include(temp => temp.Category).FirstOrDefaultAsync(x => x.ProductId == id);
        }
    }
}
