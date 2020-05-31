using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class TagInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Tags.Any())
            {
                List<Tag> tags = new List<Tag>();

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag1
                });

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag2
                });

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag3
                });

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag4
                });

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag5
                });

                tags.Add(new Tag()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigTagInitializer.Tags.Tag6
                });

                await context.AddRangeAsync(tags);
                await context.SaveChangesAsync();
            }
        }
    }
}
