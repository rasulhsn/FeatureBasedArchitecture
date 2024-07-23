using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using TMOnline.Feature.Product.Core.Abstractions;

namespace TMOnline.Feature.Product.Core.Queries.Handlers
{
    internal class ProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Shared.Entities.Product>>,
                                            IRequestHandler<GetAllProductsByYearQuery, IEnumerable<Shared.Entities.Product>>,
                                            IRequestHandler<GetProductByIdQuery, Shared.Entities.Product>
    {
        private readonly IProductDbContext _productDbContext;

        public ProductQueryHandler(IProductDbContext productDbContext)
        {
            this._productDbContext = productDbContext;
        }

        public async Task<IEnumerable<Shared.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productDbContext.DbContext
                                                .Set<Shared.Entities.Product>()
                                                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Shared.Entities.Product>> Handle(GetAllProductsByYearQuery request, CancellationToken cancellationToken)
        {
            var products = await _productDbContext.DbContext
                                                .Set<Shared.Entities.Product>()
                                                .Where(p => p.TransactionYearId == request.YearId)
                                                .ToListAsync();
            return products;
        }

        public async Task<Shared.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productDbContext.DbContext
                                                .Set<Shared.Entities.Product>()
                                                .Include(p => p.TransactionYear)
                                                    .ThenInclude(ty => ty.GroupCurrency)
                                                .SingleOrDefaultAsync(p => p.Id == request.ProductId);
            return product;
        }
    }
}
