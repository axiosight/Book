using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class PreviewConfiguration : IEntityTypeConfiguration<Preview>
    {
        public void Configure(EntityTypeBuilder<Preview> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Id).ValueGeneratedOnAdd();

            builder.Property(pr => pr.Name)
                .HasMaxLength(ConfigEntityFrameworkCore.Preview.MaxLengthName);

            builder.Property(pr => pr.Extension)
                .HasMaxLength(ConfigEntityFrameworkCore.Preview.MaxLengthExtension);

            builder.Property(pr => pr.Type)
                .HasMaxLength(ConfigEntityFrameworkCore.Preview.MaxLengthType);
        }
    }
}
