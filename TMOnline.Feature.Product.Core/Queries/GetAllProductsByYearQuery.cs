using System.Collections.Generic;
using ProductEntity = TMOnline.Shared.Entities.Product;
using MediatR;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetAllProductsByYearQuery : IRequest<IEnumerable<ProductEntity>>
    {
        public int YearId { get; }

        public GetAllProductsByYearQuery(int yearId)
        {
            YearId = yearId;
        }
    }
}
