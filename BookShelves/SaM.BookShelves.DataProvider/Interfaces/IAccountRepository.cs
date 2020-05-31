using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUser> FindByNameAccountAsync(string email);
        Task<bool> CheckPasswordAsync(AppUser account, string password);
        Task<SignInResult> SignInAsync(string email, string password, bool rememberMe, bool flag);
        Task SignOutAsync();
        Task<IEnumerable<string>> GetAccountRolesAsync(AppUser account);
    }
}
