using Ecommerce.Application.Products.Dtos;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; }
        public GetProductByIdQuery(Guid id) { this.Id = id; }
    }
}
