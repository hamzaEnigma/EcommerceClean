using Ecommerce.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddScoped<IProductsService, ProductsService>();
            services.AddAutoMapper(applicationAssembly);

        }

    }
}
