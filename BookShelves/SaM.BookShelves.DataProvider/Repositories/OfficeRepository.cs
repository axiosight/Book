using Microsoft.EntityFrameworkCore;
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
    public class OfficeRepository : IOfficeRepository
    {
        private readonly BookShelvesContext _context;

        public OfficeRepository(BookShelvesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfficeViewModel>> GetAllOffices()
        {
            var res = _context.Offices.Select(n => new OfficeViewModel()
            {
                Id = n.Id,
                Name = n.Name,
                Adress = n.Adress
            }).ToList();

            return res;
        }

        public void AddOffice(Office office)
        {
            _context.Offices.Add(office);
            _context.SaveChanges();
        }

        public void DeleteOfficeById(string officeId)
        {
            Office item = _context.Offices.Find(officeId);
            _context.Offices.Remove(item);
            _context.SaveChanges();
        }

        public Office FindOfficeById(string id)
        {
            return _context.Offices.Find(id);
        }

        public void UpdateOffice(Office item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<OfficeViewModel>> GetSearchOffice(string searchTerm)
        {
            var res = (from p in _context.Offices
                       where p.Name.Contains(searchTerm)
                       select new OfficeViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name,
                           Adress = p.Adress
                       }).ToList();
            return res;
        }

    }
}