using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync(ConfigRoleInitializer.Roles.Admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ConfigRoleInitializer.Roles.Admin));
            }
            if (await roleManager.FindByNameAsync(ConfigRoleInitializer.Roles.User) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ConfigRoleInitializer.Roles.User));
            }
            if (await roleManager.FindByNameAsync(ConfigRoleInitializer.Roles.Librarian) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ConfigRoleInitializer.Roles.Librarian));
            }

            await context.SaveChangesAsync();
        }
    }
}
