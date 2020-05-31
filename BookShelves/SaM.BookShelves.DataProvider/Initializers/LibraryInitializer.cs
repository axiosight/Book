using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class LibraryInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context)
        {
            if (!context.Libraries.Any())
            {
                List<Library> libs = new List<Library>();

                libs.Add(new Library()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigLibraryInitializer.Libraries.LibraryName1,
                    Floor = ConfigLibraryInitializer.Libraries.Floor,
                    Office = context.Offices.First(s => s.Name == ConfigOfficeInitializer.Offices.OfficeName1),
                });

                libs.Add(new Library()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigLibraryInitializer.Libraries.LibraryName2,
                    Floor = ConfigLibraryInitializer.Libraries.Floor,
                    Office = context.Offices.First(s => s.Name == ConfigOfficeInitializer.Offices.OfficeName1)
                });

                libs.Add(new Library()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ConfigLibraryInitializer.Libraries.LibraryName3,
                    Floor = ConfigLibraryInitializer.Libraries.Floor,
                    Office = context.Offices.First(s => s.Name == ConfigOfficeInitializer.Offices.OfficeName2)
                });

                await context.AddRangeAsync(libs);
                await context.SaveChangesAsync();
            }
        }
    }
}
