using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Category>> GetAll();
    }
}
