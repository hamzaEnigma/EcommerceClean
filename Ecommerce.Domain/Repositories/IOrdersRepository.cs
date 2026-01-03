using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ecommerce.Domain.Repositories
{
    public interface IOrdersRepository
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task<Guid> Add(Order order);
        public Task<Guid> AddDetail(OrderDetail orderDetail);
        public Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);

    }
}
