using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoriesRepository(EcomerceContext _dbContext) : ICategoriesRepository
    {
        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _dbContext.Categories.ToListAsync();
        }
    }
}
