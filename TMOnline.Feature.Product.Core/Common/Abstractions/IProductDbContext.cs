using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace TMOnline.Feature.Product.Core.Abstractions
{
    public interface IProductDbContext
    {
        public DbContext DbContext { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}