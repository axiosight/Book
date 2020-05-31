using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class PublisherInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Publishers.Any())
            {
                List<Publisher> publishers = new List<Publisher>();

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher1
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher2
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher3
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher4
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher5
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher6
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher7
                });

                publishers.Add(new Publisher()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigPublisherInitializer.Publishers.Publisher8
                });

                await context.AddRangeAsync(publishers);
                await context.SaveChangesAsync();
            }
        }
    }
}
