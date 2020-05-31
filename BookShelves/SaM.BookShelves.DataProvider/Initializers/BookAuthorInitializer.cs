using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class BookAuthorInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.BookAuthors.Any())
            {
                List<BookAuthor> bookAuthors = new List<BookAuthor>();

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName1)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName2)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book2.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName3)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book3.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName4)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book4.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName5)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName6)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName7)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName8)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName9)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName10)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName11)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book8.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName12)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName13)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName14)
                });

                bookAuthors.Add(new BookAuthor()
                {
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book10.Name),
                    Author = context.Authors.First(s => s.Name == ConfigAuthorInitializer.Authors.AuthorName15)
                });

                await context.AddRangeAsync(bookAuthors);
                await context.SaveChangesAsync();
            }
        }
    }
}
