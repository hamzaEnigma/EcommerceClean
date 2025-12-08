using Ecommerce.Domain.Repositories;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<EcomerceContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
            });
            services.AddScoped<IProductsRepository, ProductsRepository>();

        }

    }
}
