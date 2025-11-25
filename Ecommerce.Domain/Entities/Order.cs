
namespace Ecommerce.Domain.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
