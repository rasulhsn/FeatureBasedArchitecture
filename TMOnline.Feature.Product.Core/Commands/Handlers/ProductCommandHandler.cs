using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TMOnline.Feature.Product.Core.Abstractions;
using TMOnline.Shared.Core;
using TMOnline.Shared.Core.Exceptions;
using ProductEntity = TMOnline.Shared.Entities.Product;


namespace TMOnline.Feature.Product.Core.Commands.Handlers
{
    internal class ProductCommandHandler : IRequestHandler<AddProductCommand, ProductEntity>
    {
        private readonly IProductDbContext _productDbContext;
        private readonly IGenericMapper _mapper;

        public ProductCommandHandler(IProductDbContext productDbContext,
                                        IGenericMapper genericMapper)
        {
            _productDbContext = productDbContext;
            _mapper = genericMapper;
        }

        public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if(!request.TryValidate(out IEnumerable<string> errorMessages))
            {
                throw new ValidationErrorException(errorMessages);
            }

            bool productExists = await _productDbContext.DbContext
                                                .Set<ProductEntity>()
                                                .AnyAsync(p => p.TransactionYearId == request.TransactionYearId &&
                                                            p.Name.ToLower() == request.Name.ToLower());

            if (productExists)
            {
                throw new FeatureException(FeatureExceptionType.InvalidOperation,
                                $"Product '{request.Name}' already exists for transaction year.");
            }

            ProductEntity newProduct = _mapper.Map<AddProductCommand, ProductEntity>(request);

            await _productDbContext.DbContext.Set<ProductEntity>().AddAsync(newProduct);
            await _productDbContext.SaveChangesAsync();

            return newProduct;
        }
    }
}
