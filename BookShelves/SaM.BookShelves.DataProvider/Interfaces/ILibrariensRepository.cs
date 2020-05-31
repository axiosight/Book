using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Interfaces
{
    public interface ILibrariensRepository
    {
        Task<IEnumerable<UserViewModel>> GetAllLibrariens();
    }
}
