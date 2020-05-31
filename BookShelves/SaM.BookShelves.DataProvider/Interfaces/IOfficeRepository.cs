using SaM.BookShelves.Models.Entities;
using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.DataProvider.Interfaces
{
    public interface IOfficeRepository
    {
        Task<IEnumerable<OfficeViewModel>> GetAllOffices();
        void AddOffice(Office office);
        void DeleteOfficeById(string officeId);
        Office FindOfficeById(string id);
        void UpdateOffice(Office item);
        Task<IEnumerable<OfficeViewModel>> GetSearchOffice(string searchTerm);
    }
}
