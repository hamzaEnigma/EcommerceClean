using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Orders.Dtos
{
    public class OrderDetailsDto
    {
        public Guid ProductId { get; set; }

        public short? Quantity { get; set; }

        public decimal? SalePrice { get; set; }

    }
}
