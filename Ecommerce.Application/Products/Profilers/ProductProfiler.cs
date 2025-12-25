using AutoMapper;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Application.Products.Dtos;
using Ecommerce.Application.Products.Dtos.Categories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Products.Profilers
{
    public class ProductProfiler : Profile
    {
        public ProductProfiler()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateProductCommand, Product>();

        }
    }
}
