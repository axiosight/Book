using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(bt => new { bt.BookId, bt.TagId });

            builder.HasOne(b => b.Book)
                .WithMany(bt => bt.BookTags)
                .HasForeignKey(b => b.BookId);

            builder.HasOne(t => t.Tag)
                .WithMany(bt => bt.BookTags)
                .HasForeignKey(t => t.TagId);
        }
    }
}
