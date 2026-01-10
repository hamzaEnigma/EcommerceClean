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
                    OrderDate =  DateTime.UtcNow
                };
                await _ordersRepository.Add(order);

                // fetch all products at once
                var productIds= request.OrderDetails.Select(id=>id.ProductId).ToList();
                var products = await _productsRepository.GetByIdsAsync(productIds);

                foreach (var detail in request.OrderDetails)
                {
                    var product = products.FirstOrDefault(p => p.ProductId == detail.ProductId) ?? throw new Exception($"Produit avec id^{detail.ProductId} est inexistant"); ;

                    OrderDetail orderDetail = new OrderDetail()
                    {
                        ProductId = detail.ProductId,
                        Quantity = detail.Quantity,
                        SalePrice = product.SellPrice ?? 0,
                        OrderId = order.OrderId
                    };
                    await _ordersRepository.AddDetail(orderDetail);

                }
                await trasaction.CommitAsync(cancellationToken);
                // END of transaction

                return order.OrderId;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                await trasaction.RollbackAsync(cancellationToken);
                throw new Exception($"Erreur lors de la création de la commande : {ex.Message}", ex);
            }

        }
    }

}
