using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class AuthorInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Authors.Any())
            {
                List<Author> authors = new List<Author>();

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName1
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName2
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName3
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName4
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName5
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName6
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName7
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName8
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName9
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName10
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName11
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName12
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName13
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName14
                });

                authors.Add(new Author()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigAuthorInitializer.Authors.AuthorName15
                });

                await context.AddRangeAsync(authors);
                await context.SaveChangesAsync();
            }
        }
    }
}
