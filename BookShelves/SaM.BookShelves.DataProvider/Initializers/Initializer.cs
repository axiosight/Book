using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.Models.Entities;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public class Initializer
    {
        public static async Task SeedAsync(BookShelvesContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await RoleInitializer.InitializeAsync(context, userManager, roleManager);
            await AuthorInitializer.InitializeAsync(context);
            await TagInitializer.InitializeAsync(context);
            await PublisherInitializer.InitializeAsync(context);
            await StatusInitializer.InitializeAsync(context);
            await OfficeInitializer.InitializeAsync(context);
            await LibraryInitializer.InitializeAsync(context);
            await AppUserInitializer.InitializeAsync(context, userManager, roleManager);
            await BookInitializer.InitializeAsync(context);
            await BookAuthorInitializer.InitializeAsync(context);
            await BookPublisherInitializer.InitializeAsync(context);
            await BookTagInitializer.InitializeAsync(context);
            await PreviewInitializer.InitializeAsync(context);
            await BookEntityInitializer.InitializeAsync(context);

            await context.SaveChangesAsync();
        }
    }
}