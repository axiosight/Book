using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.DataProvider.ModelConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(abe => abe.BookEntities)
                .WithOne(a => a.AppUser)
                .HasForeignKey(a => a.AppUserId);

            builder.Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.AppUser.MaxLengthUserName);

            builder.Property(a => a.Surname)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.AppUser.MaxLengthSurname);

            builder.Property(a => a.Floor)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.AppUser.MaxLengthFloor);

            builder.Property(a => a.Room)
                .IsRequired()
                .HasMaxLength(ConfigEntityFrameworkCore.AppUser.MaxLengthRoom);
        }
    }
}
