using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Repositories
{
    public class AccountRepository :  IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AppUser> FindByNameAccountAsync(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(AppUser account, string password)
        {
            return await _userManager.CheckPasswordAsync(account, password);
        }

        public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe, bool flag)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, flag);
        }

        public Task SignOutAsync()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task<IEnumerable<string>> GetAccountRolesAsync(AppUser account)
        {
            return await _userManager.GetRolesAsync(account);
        }

    }
}
