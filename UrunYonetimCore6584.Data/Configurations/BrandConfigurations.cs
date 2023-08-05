using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrunYonetimCore6584.Core.Entities;

namespace UrunYonetimCore6584.Data.Configurations
{
    //  aşağıdaki yapı brand class ının veritabanı yapılandırmasını ayarlar
    internal class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50); // marka class ının name özelliği zorunlu (not null) olsun ve karakter sayısı 50 olsun
            builder.Property(x => x.Logo).HasMaxLength(100);
        }
    }
}
