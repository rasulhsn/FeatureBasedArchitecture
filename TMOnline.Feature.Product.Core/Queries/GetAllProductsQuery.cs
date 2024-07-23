using System.Collections.Generic;

using MediatR;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Shared.Entities.Product>> { }
}
