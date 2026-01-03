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
            await SaveChangesAsync();
            return product.ProductId;
        }

        public async Task DeleteAsync(Product product)
        {
            _dbContext.Products.Remove(product);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _dbContext.Products.Include(temp => temp.Category).ToListAsync();
            return products;
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _dbContext.Products.Include(temp => temp.Category).FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task<List<Product>> GetByIdsAsync(List<Guid> ids)
        {
           var tasks = ids.Select(id => GetById(id));
            var products = await Task.WhenAll(tasks);
            return products.Where(p => p != null).ToList()!;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
