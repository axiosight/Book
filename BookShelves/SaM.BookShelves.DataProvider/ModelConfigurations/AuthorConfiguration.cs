using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Author.MaxLengthName);
        }
    }
}
