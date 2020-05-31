using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class StatusInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Statuses.Any())
            {
                List<Status> statuses = new List<Status>();

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.InLib
                });

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.Booked
                });

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.GivenToUser
                });

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.Ready,
                });

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.Denied
                });

                statuses.Add(new Status()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigStatusInitializer.Statuses.Transferred
                });

                await context.AddRangeAsync(statuses);
                await context.SaveChangesAsync();
            }
        }
    }
}
