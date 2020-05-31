using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.HasMany<Library>(ol => ol.Libraries)
                .WithOne(o => o.Office)
                .HasForeignKey(o => o.OfficeId);

            builder.HasMany<AppUser>(oa => oa.AppUsers)
                .WithOne(o => o.Office)
                .HasForeignKey(o => o.OfficeId);

            builder.Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Office.MaxLengthName);

            builder.Property(o => o.Adress)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Office.MaxLengthAdress);
        }
    }
}
