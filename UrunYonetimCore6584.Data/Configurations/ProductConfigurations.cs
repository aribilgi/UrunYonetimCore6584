using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrunYonetimCore6584.Core.Entities;

namespace UrunYonetimCore6584.Data.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).HasMaxLength(100);
            builder.Property(x => x.Image2).HasMaxLength(100);
            builder.Property(x => x.Image3).HasMaxLength(100);
            // FluentAPI ile class lar arası ilişki kurma
            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(f => f.BrandId); // Burada marka ile ürünler arasında bire çok bir ilişki olduğunu ifade ettik
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(f => f.CategoryId);
        }
    }
}
