using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TMOnline.Feature.Product.Infrastructure.Extensions;
using TMOnline.Feature.Product.Core.Extensions;

namespace TMOnline.Feature.Product.Web
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddProductFeature(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddProductCore()
                .AddProductInfrastructure(configuration);

            return services;
        }
    }
}