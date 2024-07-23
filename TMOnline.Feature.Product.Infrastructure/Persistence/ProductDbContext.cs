using Microsoft.EntityFrameworkCore;

using TMOnline.Feature.Product.Core.Abstractions;
using TMOnline.Shared.Infrastructure.Persistence;

namespace TMOnline.Feature.Product.Infrastructure.Persistence
{
    public class ProductDbContext : FeatureDbContext, IProductDbContext
    {
        protected override string Schema => string.Empty;

        public DbContext DbContext => this;

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Shared.Entities.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}