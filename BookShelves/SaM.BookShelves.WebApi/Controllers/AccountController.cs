using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaM.BookShelves.Common.Routes;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.ViewModels;

namespace SaM.BookShelves.WebApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(RoutesApi.Account.Login)]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model)
        {
            var authResponse = await _accountService.SignIn(model);

            if (!authResponse.Result)
            {
                return BadRequest(new ResponseViewModel
                {
                    Message = authResponse.Message
                });
            }
            else
            {
                return Ok(new ResponseViewModel
                {
                    Message = authResponse.Message
                });
            }
        }

        [HttpPost(RoutesApi.Account.LogOut)]
        public async Task Logout()
        {
            await _accountService.SignOut();
        }

        [HttpGet(RoutesApi.Account.GetAccount)]
        public async Task<IActionResult> GetAccount()
        {
            var email = User.Identity.Name;

            if (email != null)
            {
                var user = await _accountService.FindByEmailAsync(email);

                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    Mobile = user.Mobile,
                    Floor = user.Floor,
                    Room = user.Room,
                    Roles = user.Roles
                });
            }

            return Ok(new UserViewModel
            {
                Roles = new List<string>()
            });
        }
    }
}