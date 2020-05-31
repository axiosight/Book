using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasMany(sbe => sbe.BookEntities)
                .WithOne(s => s.Status)
                .HasForeignKey(s => s.StatusId);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.Status.MaxLengthName);
        }
    }
}
