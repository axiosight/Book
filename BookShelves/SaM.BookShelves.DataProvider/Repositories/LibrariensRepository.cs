using Microsoft.AspNetCore.Identity;
using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Models.Entities;
using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Repositories
{
    public class LibrariensRepository : ILibrariensRepository
    {
        private readonly BookShelvesContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LibrariensRepository(BookShelvesContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllLibrariens()
        {
            var a = await _userManager.GetUsersInRoleAsync("librarian");

            var res = a.Select(x => new UserViewModel()
            {
                UserId = x.Id,
                Email = x.Email,
                Name = x.AppUserName,
                Surname = x.Surname,
                Mobile = x.PhoneNumber,
                Floor = x.Floor,
                Room = x.Room,
                OfficeId = x.OfficeId,
                OfficeName = GetOfficeNameById(x.OfficeId)
            }).ToList();

            return res;
        }

        public string GetOfficeNameById(string id)
        {
            var office = _context.Offices.Find(id);
            return office.Name;
        }
    }
}
