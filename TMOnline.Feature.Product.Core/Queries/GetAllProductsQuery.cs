using System.Collections.Generic;
using ProductEntity = TMOnline.Shared.Entities.Product;
using MediatR;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>> { }
}
