using Ecommerce.Application.Products.Dtos;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}
