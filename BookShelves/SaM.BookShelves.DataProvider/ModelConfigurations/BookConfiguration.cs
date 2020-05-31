using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasMany(be => be.BookEntities)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            builder.HasMany(bpr => bpr.Previews)
                .WithOne(b => b.Book)
                .HasForeignKey(b => b.BookId);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Book.MaxLengthName);

            builder.Property(b => b.OriginalName)
                .HasMaxLength(ConfigEntityFrameworkCore.Book.MaxLengthOriginalName);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Book.MaxLengthDescription);

            builder.Property(b => b.Year)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Book.MaxLengthYear);
        }
    }
}
