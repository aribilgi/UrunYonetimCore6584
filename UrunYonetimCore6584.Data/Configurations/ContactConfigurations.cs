using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrunYonetimCore6584.Core.Entities;

namespace UrunYonetimCore6584.Data.Configurations
{
    internal class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).HasMaxLength(50);
            builder.Property(x => x.Telephone).HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Message).IsRequired().HasMaxLength(1500);
        }
    }
}
