
namespace Ecommerce.Domain.Entities;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public Guid OrderId { get; set; }

    public Guid ProductId { get; set; }

    public short Quantity { get; set; }

    public decimal SalePrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
