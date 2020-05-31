using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class OfficeInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Offices.Any())
            {
                List<Office> offices = new List<Office>();

                offices.Add(new Office()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigOfficeInitializer.Offices.OfficeName1,
                    Adress = ConfigOfficeInitializer.Offices.OfficeAdress1
                });

                offices.Add(new Office()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigOfficeInitializer.Offices.OfficeName2,
                    Adress = ConfigOfficeInitializer.Offices.OfficeAdress2
                });

                await context.AddRangeAsync(offices);
                await context.SaveChangesAsync();
            }
        }
    }
}
