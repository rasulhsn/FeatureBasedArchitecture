using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProductEntity = TMOnline.Shared.Entities.Product; 
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMOnline.Feature.Product.Core.Abstractions;

namespace TMOnline.Feature.Product.Core.Queries.Handlers
{
    internal class ProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>,
                                            IRequestHandler<GetAllProductsByYearQuery, IEnumerable<ProductEntity>>,
                                            IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        private readonly IProductDbContext _productDbContext;

        public ProductQueryHandler(IProductDbContext productDbContext) => _productDbContext = productDbContext;

        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productDbContext.DbContext
                                                .Set<ProductEntity>()
                                                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsByYearQuery request, CancellationToken cancellationToken)
        {
            var products = await _productDbContext.DbContext
                                                .Set<ProductEntity>()
                                                .Where(p => p.TransactionYearId == request.YearId)
                                                .ToListAsync();
            return products;
        }

        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productDbContext.DbContext
                                                .Set<ProductEntity>()
                                                .Include(p => p.TransactionYear)
                                                    .ThenInclude(ty => ty.GroupCurrency)
                                                .SingleOrDefaultAsync(p => p.Id == request.ProductId);
            return product;
        }
    }
}
