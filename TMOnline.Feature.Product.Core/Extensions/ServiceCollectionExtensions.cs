using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace TMOnline.Feature.Product.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductCore(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(currentAssembly);

            return services;
        }
    }
}