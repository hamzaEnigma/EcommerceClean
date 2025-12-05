using Ecommerce.Application.Products.Dtos.Categories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Products.Dtos
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal? SellPrice { get; set; }

        public Guid? CategoryId { get; set; }

        public short? UnitsInStock { get; set; }

        public int? StockLimit { get; set; }

        public virtual CategoryDto? Category { get; set; }

    }
}
