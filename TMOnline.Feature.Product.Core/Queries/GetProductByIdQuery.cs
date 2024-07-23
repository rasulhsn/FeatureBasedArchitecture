using MediatR;

namespace TMOnline.Feature.Product.Core.Queries
{
    public class GetProductByIdQuery : IRequest<Shared.Entities.Product>
    {
        public int ProductId { get; }

        public GetProductByIdQuery(int productId)
        {
            this.ProductId = productId;
        }
    }
}
