
namespace Ecommerce.Domain.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal PurchasePrice { get; set; }

    public decimal? SellPrice { get; set; }

    public Guid? CategoryId { get; set; }

    public short? UnitsInStock { get; set; }

    public int? StockLimit { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
