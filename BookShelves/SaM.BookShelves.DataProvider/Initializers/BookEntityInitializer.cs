using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class BookEntityInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.BookEntities.Any())
            {
                List<BookEntity> bookEntities = new List<BookEntity>();

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book1.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book2.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book3.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book4.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book8.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book9.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book10.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book11.Name)
                });

                //=====================2=============
                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName2),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book5.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName2),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book6.Name)
                });

                bookEntities.Add(new BookEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName2),
                    Status = context.Statuses.First(s => s.Name == ConfigStatusInitializer.Statuses.InLib),
                    Book = context.Books.First(s => s.Name == ConfigBookInitializer.Books.Book7.Name)
                });

                await context.AddRangeAsync(bookEntities);
                await context.SaveChangesAsync();
            }
        }
    }
}
