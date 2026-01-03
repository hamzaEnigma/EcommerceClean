using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly EcomerceContext _dbContext;

        public OrdersRepository(EcomerceContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Add(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.OrderId;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.Include(data => data.OrderDetails)
                                        .ThenInclude(data => data.Product)
                                        .ToListAsync();
        }

        public async Task<Guid> AddDetail(OrderDetail orderDetail) 
        { 
            _dbContext.OrderDetails.Add(orderDetail);
            await _dbContext.SaveChangesAsync();
            return orderDetail.OrderDetailId;
        }

        public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken)
        {
           return  await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
