using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace TMOnline.Shared.Infrastructure.Persistence
{
    public abstract class FeatureDbContext : DbContext
    {
        protected abstract string Schema { get; }

        protected FeatureDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Schema))
            {
                modelBuilder.HasDefaultSchema(Schema);
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => (await base.SaveChangesAsync(true, cancellationToken));
    }
}