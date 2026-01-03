using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Dtos;
using Ecommerce.Application.Orders.Validators;
using Ecommerce.Application.Products;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IValidator<OrderDetailsDto>, CreateOrderDetailValidator>();
            services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));
            services.AddAutoMapper(applicationAssembly);

        }

    }
}
