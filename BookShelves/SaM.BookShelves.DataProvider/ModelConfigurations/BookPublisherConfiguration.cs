using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class BookPublisherConfiguration : IEntityTypeConfiguration<BookPublisher>
    {
        public void Configure(EntityTypeBuilder<BookPublisher> builder)
        {
            builder.HasKey(bp => new { bp.BookId, bp.PublisherId });

            builder.HasOne<Book>(b => b.Book)
                .WithMany(bp => bp.BookPublishers)
                .HasForeignKey(b => b.BookId);

            builder.HasOne<Publisher>(p => p.Publisher)
                .WithMany(bp => bp.BookPublishers)
                .HasForeignKey(p => p.PublisherId);
        }
    }
}
