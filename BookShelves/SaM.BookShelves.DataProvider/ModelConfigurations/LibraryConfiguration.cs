using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.HasMany(la => la.AppUsers)
                .WithOne(l => l.Library)
                .HasForeignKey(l => l.LibraryId);

            builder.HasMany(lbe => lbe.BookEntities)
                .WithOne(l => l.Library)
                .HasForeignKey(l => l.LibraryId);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Library.MaxLengthName);

            builder.Property(l => l.Floor)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Library.MaxLengthFloor);
        }
    }
}
