using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using TMOnline.Feature.Product.Core.Abstractions;
using TMOnline.Shared.Core;
using TMOnline.Shared.Core.Exceptions;

namespace TMOnline.Feature.Product.Core.Commands.Handlers
{
    internal class ProductCommandHandler : IRequestHandler<AddProductCommand, Shared.Entities.Product>
    {
        private readonly IProductDbContext _productDbContext;
        private readonly IGenericMapper _mapper;

        public ProductCommandHandler(IProductDbContext productDbContext,
                                        IGenericMapper genericMapper)
        {
            this._productDbContext = productDbContext;
            this._mapper = genericMapper;
        }

        public async Task<Shared.Entities.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if(!request.TryValidate(out IEnumerable<string> errorMessages))
            {
                throw new ValidationErrorException(errorMessages);
            }

            bool productExists = await _productDbContext.DbContext
                                                .Set<Shared.Entities.Product>()
                                                .AnyAsync(p => p.TransactionYearId == request.TransactionYearId &&
                                                            p.Name.ToLower() == request.Name.ToLower());

            if (productExists)
            {
                throw new FeatureException(FeatureExceptionType.InvalidOperation,
                                $"Product '{request.Name}' already exists for transaction year.");
            }

            Shared.Entities.Product newProduct = _mapper.Map<AddProductCommand, Shared.Entities.Product>(request);

            await _productDbContext.DbContext.Set<Shared.Entities.Product>().AddAsync(newProduct);
            await _productDbContext.SaveChangesAsync();

            return newProduct;
        }
    }
}
