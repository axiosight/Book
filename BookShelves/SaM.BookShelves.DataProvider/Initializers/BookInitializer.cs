using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class BookInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Books.Any())
            {
                List<Book> books = new List<Book>();

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book1.Name,
                    OriginalName = ConfigBookInitializer.Books.Book1.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book1.ISBN,
                    Year = ConfigBookInitializer.Books.Book1.Year,
                    Description = ConfigBookInitializer.Books.Book1.Description,
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book2.Name,
                    OriginalName = ConfigBookInitializer.Books.Book2.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book2.ISBN,
                    Year = ConfigBookInitializer.Books.Book2.Year,
                    Description = ConfigBookInitializer.Books.Book2.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book3.Name,
                    OriginalName = ConfigBookInitializer.Books.Book3.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book3.ISBN,
                    Year = ConfigBookInitializer.Books.Book3.Year,
                    Description = ConfigBookInitializer.Books.Book3.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book4.Name,
                    OriginalName = ConfigBookInitializer.Books.Book4.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book4.ISBN,
                    Year = ConfigBookInitializer.Books.Book4.Year,
                    Description = ConfigBookInitializer.Books.Book4.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book5.Name,
                    OriginalName = ConfigBookInitializer.Books.Book5.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book5.ISBN,
                    Year = ConfigBookInitializer.Books.Book5.Year,
                    Description = ConfigBookInitializer.Books.Book5.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book6.Name,
                    OriginalName = ConfigBookInitializer.Books.Book6.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book6.ISBN,
                    Year = ConfigBookInitializer.Books.Book6.Year,
                    Description = ConfigBookInitializer.Books.Book6.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book7.Name,
                    OriginalName = ConfigBookInitializer.Books.Book7.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book7.ISBN,
                    Year = ConfigBookInitializer.Books.Book7.Year,
                    Description = ConfigBookInitializer.Books.Book7.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book8.Name,
                    OriginalName = ConfigBookInitializer.Books.Book8.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book8.ISBN,
                    Year = ConfigBookInitializer.Books.Book8.Year,
                    Description = ConfigBookInitializer.Books.Book8.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book9.Name,
                    OriginalName = ConfigBookInitializer.Books.Book9.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book9.ISBN,
                    Year = ConfigBookInitializer.Books.Book9.Year,
                    Description = ConfigBookInitializer.Books.Book9.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book10.Name,
                    OriginalName = ConfigBookInitializer.Books.Book10.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book10.ISBN,
                    Year = ConfigBookInitializer.Books.Book10.Year,
                    Description = ConfigBookInitializer.Books.Book10.Description
                });

                books.Add(new Book()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigBookInitializer.Books.Book11.Name,
                    OriginalName = ConfigBookInitializer.Books.Book11.OriginalName,
                    ISBN = ConfigBookInitializer.Books.Book11.ISBN,
                    Year = ConfigBookInitializer.Books.Book11.Year,
                    Description = ConfigBookInitializer.Books.Book11.Description
                });

                await context.AddRangeAsync(books);
                await context.SaveChangesAsync();
            }
        }
    }
}