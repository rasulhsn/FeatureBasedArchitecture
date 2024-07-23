using System.Collections.Generic;

using MediatR;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetAllProductsByYearQuery : IRequest<IEnumerable<Shared.Entities.Product>>
    {
        public int YearId { get; }

        public GetAllProductsByYearQuery(int yearId)
        {
            this.YearId = yearId;
        }
    }
}
