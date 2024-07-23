using System.Linq;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TMOnline.Feature.Product.Core.Abstractions;
using TMOnline.Feature.Product.Infrastructure.Persistence;
using TMOnline.Shared.Infrastructure.Extensions;

namespace TMOnline.Feature.Product.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDatabaseContext<ProductDbContext>(config)
                .AddScoped<IProductDbContext>(provider => provider.GetService<ProductDbContext>());

            services.AddSingleton<IGenericMapper>(provider =>
            {
                AssemblyName profileAssembly = Assembly.GetExecutingAssembly()
                        .GetReferencedAssemblies()
                        .First(x => x.Name.Contains(nameof(TMOnline.Feature.Product.Core)));

                return new GenericMapper(Assembly.Load(profileAssembly));
            });

            return services;
        }
    }
}