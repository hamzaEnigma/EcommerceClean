using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Orders.Dtos
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; } = new List<OrderDetailsDto>();
    }
}
