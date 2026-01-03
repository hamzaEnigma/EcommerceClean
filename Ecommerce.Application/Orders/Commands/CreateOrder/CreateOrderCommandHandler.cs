using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler(IOrdersRepository _ordersRepository,IProductsRepository _productsRepository, ILogger<CreateOrderCommandHandler> _logger)
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating order");

            // start transaction 

            using var trasaction = await _ordersRepository.BeginTransaction(cancellationToken);
            try
            {
                // create main order
                var order = new Order()
                {
                    OrderId = Guid.NewGuid(),
                    OrderDate = request.OrderDate ?? DateTime.UtcNow
                };
                await _ordersRepository.Add(order);

                // fetch all products at once
                var productIds= request.OrderDetails.Select(id=>id.ProductId).ToList();
                var products = await _productsRepository.GetByIdsAsync(productIds);

                foreach (var detail in request.OrderDetails)
                {
                    var product = products.First(p => p.ProductId == detail.ProductId);

                    OrderDetail orderDetail = new OrderDetail()
                    {
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity ?? 1,
                        SalePrice = product.SellPrice ?? throw new Exception($"Produit avec id : {product.ProductId} has sale price negative"),
                        OrderId = order.OrderId
                    };
                    await _ordersRepository.AddDetail(orderDetail);

                    // END of transaction
                    await trasaction.CommitAsync(cancellationToken);
                }
                return order.OrderId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                await trasaction.RollbackAsync(cancellationToken);
                throw;
            }

        }
    }

}
