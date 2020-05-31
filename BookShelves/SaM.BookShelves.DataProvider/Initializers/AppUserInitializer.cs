using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Initializers
{
    public static class AppUserInitializer
    {
        public static async Task InitializeAsync(BookShelvesContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await userManager.FindByNameAsync(ConfigAppUserInitializer.Users.adminEmail) == null)
            {
                AppUser admin = new AppUser { 
                    Email = ConfigAppUserInitializer.Users.adminEmail,
                    UserName = ConfigAppUserInitializer.Users.adminEmail,
                    EmailConfirmed = true,
                    AppUserName = ConfigAppUserInitializer.Users.UserName1,
                    Surname = ConfigAppUserInitializer.Users.UserSurname1,
                    PhoneNumber = ConfigAppUserInitializer.Users.UserPhone,
                    Floor = ConfigAppUserInitializer.Users.Floor1,
                    Room = ConfigAppUserInitializer.Users.Room1
                };

                var result = await userManager.CreateAsync(admin, ConfigAppUserInitializer.Users.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ConfigRoleInitializer.Roles.Admin);
                }
            }
            if (await userManager.FindByNameAsync(ConfigAppUserInitializer.Users.libEmail) == null)
            {
                AppUser librarian = new AppUser
                {
                    Email = ConfigAppUserInitializer.Users.libEmail,
                    UserName = ConfigAppUserInitializer.Users.libEmail,
                    EmailConfirmed = true,
                    AppUserName = ConfigAppUserInitializer.Users.UserName2,
                    Surname = ConfigAppUserInitializer.Users.UserSurname2,
                    PhoneNumber = ConfigAppUserInitializer.Users.UserPhone,
                    Floor = ConfigAppUserInitializer.Users.Floor2,
                    Room = ConfigAppUserInitializer.Users.Room2,
                    Office = context.Offices.First(s => s.Name == ConfigOfficeInitializer.Offices.OfficeName1),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName1)
                };

                var result = await userManager.CreateAsync(librarian, ConfigAppUserInitializer.Users.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(librarian, ConfigRoleInitializer.Roles.Librarian);
                }
            }
            if (await userManager.FindByNameAsync(ConfigAppUserInitializer.Users.libEmail2) == null)
            {
                AppUser librarian = new AppUser
                {
                    Email = ConfigAppUserInitializer.Users.libEmail2,
                    UserName = ConfigAppUserInitializer.Users.libEmail2,
                    EmailConfirmed = true,
                    AppUserName = ConfigAppUserInitializer.Users.UserName3,
                    Surname = ConfigAppUserInitializer.Users.UserSurname3,
                    PhoneNumber = ConfigAppUserInitializer.Users.UserPhone,
                    Floor = ConfigAppUserInitializer.Users.Floor3,
                    Room = ConfigAppUserInitializer.Users.Room3,
                    Office = context.Offices.First(s => s.Name == ConfigOfficeInitializer.Offices.OfficeName2),
                    Library = context.Libraries.First(s => s.Name == ConfigLibraryInitializer.Libraries.LibraryName3)
                };

                var result = await userManager.CreateAsync(librarian, ConfigAppUserInitializer.Users.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(librarian, ConfigRoleInitializer.Roles.Librarian);
                }
            }
            if (await userManager.FindByNameAsync(ConfigAppUserInitializer.Users.userEmail) == null)
            {
                AppUser user = new AppUser
                {
                    Email = ConfigAppUserInitializer.Users.userEmail,
                    UserName = ConfigAppUserInitializer.Users.userEmail,
                    EmailConfirmed = true,
                    AppUserName = ConfigAppUserInitializer.Users.UserName4,
                    Surname = ConfigAppUserInitializer.Users.UserSurname4,
                    PhoneNumber = ConfigAppUserInitializer.Users.UserPhone,
                    Floor = ConfigAppUserInitializer.Users.Floor4,
                    Room = ConfigAppUserInitializer.Users.Room4,
                };

                var result = await userManager.CreateAsync(user, ConfigAppUserInitializer.Users.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ConfigRoleInitializer.Roles.User);
                }
            }
            if (await userManager.FindByNameAsync(ConfigAppUserInitializer.Users.userEmail2) == null)
            {
                AppUser user = new AppUser
                {
                    Email = ConfigAppUserInitializer.Users.userEmail2,
                    UserName = ConfigAppUserInitializer.Users.userEmail2,
                    EmailConfirmed = true,
                    AppUserName = ConfigAppUserInitializer.Users.UserName5,
                    Surname = ConfigAppUserInitializer.Users.UserSurname5,
                    PhoneNumber = ConfigAppUserInitializer.Users.UserPhone,
                    Floor = ConfigAppUserInitializer.Users.Floor5,
                    Room = ConfigAppUserInitializer.Users.Room5
                };

                var result = await userManager.CreateAsync(user, ConfigAppUserInitializer.Users.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, ConfigRoleInitializer.Roles.User);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
