using MediatR;
using ProductEntity = TMOnline.Shared.Entities.Product;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public int ProductId { get; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
