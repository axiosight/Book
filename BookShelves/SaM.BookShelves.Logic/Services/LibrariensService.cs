using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaM.BookShelves.Logic.Services
{
    public class LibrariensService : ILibrariensService
    {
        private readonly ILibrariensRepository _librariensRepository;

        public LibrariensService(ILibrariensRepository librariensRepository)
        {
            _librariensRepository = librariensRepository; 
        }

        public async Task<IEnumerable<UserViewModel>> GetAllLibrariens()
        {
            return await _librariensRepository.GetAllLibrariens();
        }
    }
}
