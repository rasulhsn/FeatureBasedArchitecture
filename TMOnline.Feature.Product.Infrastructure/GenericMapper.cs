using System.Reflection;

using AutoMapper;

using TMOnline.Feature.Product.Core.Abstractions;
using TMOnline.Shared.Infrastructure.AutoMapper;

namespace TMOnline.Feature.Product.Infrastructure
{
    public class GenericMapper : IGenericMapper
    {
        private readonly IMapper _autoMapper;

        public GenericMapper(Assembly assembly)
        {
            this._autoMapper = AutoMapperFactory.Create(assembly);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return this._autoMapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return this._autoMapper.Map<TDestination>(source);
        }
    }
}
