using Ecommerce.Application.Orders.Dtos;
using MediatR;

namespace Ecommerce.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; } = new List<OrderDetailsDto>();
    }
}
