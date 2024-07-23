namespace TMOnline.Feature.Product.Core.Abstractions
{
    public interface IGenericMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source);
    }
}
