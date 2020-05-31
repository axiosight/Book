using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class BookPublisherInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.BookPublishers.Any())
            {
                List<BookPublisher> bookPublishers = new List<BookPublisher>();

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher1)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher2)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book2.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher3)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book3.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher3)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book4.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher4)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher1)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher4)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher4)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book8.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher5)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher6)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book10.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher7)
                });

                bookPublishers.Add(new BookPublisher
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book11.Name),
                    Publisher = context.Publishers.First(s => s.Name == ConfigPublisherInitializer.Publishers.Publisher8)
                });

                await context.AddRangeAsync(bookPublishers);
                await context.SaveChangesAsync();
            }
        }
    }
}
