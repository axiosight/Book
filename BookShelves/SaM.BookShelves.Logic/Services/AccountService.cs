using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaM.BookShelves.Logic.Services
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ResponseViewModel> SignIn(LoginViewModel model)
        {
            var account = await _accountRepository.FindByNameAccountAsync(model.Email);

            if (account == null)
            {
                return new ResponseViewModel
                {
                    Result = false,
                    Message = "User does not exist!"
                };
            }

            var passwordValid = await _accountRepository.CheckPasswordAsync(account, model.Password);

            if (!passwordValid)
            {
                return new ResponseViewModel
                {
                    Result = false,
                    Message = "Wrong password!"
                };
            }

            await _accountRepository.SignInAsync(model.Email, model.Password, false, false);

            return new ResponseViewModel
            {
                Result = true,
                Message = "Welcome!"
            };
        }

        public async Task SignOut()
        {
            await _accountRepository.SignOutAsync();
        }

        public async Task<UserViewModel> FindByEmailAsync(string email)
        {
            var account = await _accountRepository.FindByNameAccountAsync(email);

            IEnumerable<string> userRoles = await _accountRepository.GetAccountRolesAsync(account);

            return new UserViewModel
            {
                UserId = account.Id,
                Email = account.Email,
                Name = account.AppUserName,
                Surname = account.Surname,
                Mobile = account.PhoneNumber,
                Floor = account.Floor,
                Room = account.Room,
                Roles = userRoles
            };
        }
    }
}
