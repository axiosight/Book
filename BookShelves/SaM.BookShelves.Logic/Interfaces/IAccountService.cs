using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.Logic.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseViewModel> SignIn(LoginViewModel model);
        Task SignOut();
        Task<UserViewModel> FindByEmailAsync(string email);
    }
}
