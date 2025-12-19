using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Products.Commands.CreateProduct
{
    public class CreateProductQuery : IRequest<Guid>
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal? SellPrice { get; set; }

        public Guid? CategoryId { get; set; }

        public short? UnitsInStock { get; set; }

        public int? StockLimit { get; set; }

    }
}
