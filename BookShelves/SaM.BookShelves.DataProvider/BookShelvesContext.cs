using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaM.BookShelves.Models.Entities;
using System.Reflection;

namespace SaM.BookShelves.DataProvider
{
    public class BookShelvesContext : IdentityDbContext<AppUser>
    {
        public BookShelvesContext(DbContextOptions<BookShelvesContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookEntity> BookEntities { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Preview> Previews { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
