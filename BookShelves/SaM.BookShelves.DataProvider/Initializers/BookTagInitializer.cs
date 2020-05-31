using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class BookTagInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.BookTags.Any())
            {
                List<BookTag> bookTags = new List<BookTag>();

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag1)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book2.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag2)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book3.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag3)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book4.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag4)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag4)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag5)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag4)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag5)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag1)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag4)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag5)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book8.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag4)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag6)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book10.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag2)
                });

                bookTags.Add(new BookTag()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book11.Name),
                    Tag = context.Tags.First(s => s.Name == ConfigTagInitializer.Tags.Tag2)
                });

                await context.AddRangeAsync(bookTags);
                await context.SaveChangesAsync();
            }
        }
    }
}
