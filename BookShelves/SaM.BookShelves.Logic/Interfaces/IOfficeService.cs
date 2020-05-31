using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.Logic.Interfaces
{
    public interface IOfficeService
    {
        Task<IEnumerable<OfficeViewModel>> GetAllOffices();
        Task<ResponseViewModel> AddOffice(OfficeViewModel model);
        void DeleteOfficeById(string officeId);
        ResponseViewModel UpdateOffice(OfficeViewModel model);
        Task<IEnumerable<OfficeViewModel>> GetSearchOffice(string searchTerm);
    }
}
