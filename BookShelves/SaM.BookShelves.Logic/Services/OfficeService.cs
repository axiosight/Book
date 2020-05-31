using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.Entities;
using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BookShelves.Logic.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;

        public OfficeService(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<IEnumerable<OfficeViewModel>> GetAllOffices()
        {
            return await _officeRepository.GetAllOffices();
        }

        public async Task<ResponseViewModel> AddOffice(OfficeViewModel model)
        {
            var office = new Office()
            {
                Name = model.Name,
                Adress = model.Adress
            };

            if(office != null)
            {
                _officeRepository.AddOffice(office);
                return new ResponseViewModel()
                {
                    Result = true,
                    Message = "Office add!"
                };
            }
            else
            {
                return new ResponseViewModel()
                {
                    Result = false,
                    Message = "Office not add!"
                };
            }
        }

        public void DeleteOfficeById(string officeId)
        {
            _officeRepository.DeleteOfficeById(officeId);
        }

        public ResponseViewModel UpdateOffice(OfficeViewModel model)
        {

            var office = _officeRepository.FindOfficeById(model.Id);

            if(office != null)
            {
                office.Name = model.Name;
                office.Adress = model.Adress;
                _officeRepository.UpdateOffice(office);
                return new ResponseViewModel()
                {
                    Message = "Update!",
                    Result = true
                };
            }
            else
            {
                return new ResponseViewModel()
                {
                    Message = "Not Update!",
                    Result = false
                };
            }
        }

        public async Task<IEnumerable<OfficeViewModel>> GetSearchOffice(string searchTerm)
        {
            if (searchTerm == null)
            {
                return await _officeRepository.GetAllOffices();
            }
            else
            {
                return await _officeRepository.GetSearchOffice(searchTerm);
            }
        }
    }
}
