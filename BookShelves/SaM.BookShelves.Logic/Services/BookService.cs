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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<IEnumerable<BookViewModel>> GetSearchBooks(string tagSearch, string termSearch)
        {
            if (termSearch == null && (tagSearch == null || string.Equals(tagSearch, "Empty")))
            {
                return await _bookRepository.GetAllBooks();
            }
            else
            {
                return await _bookRepository.GetSearchBooks(tagSearch, termSearch);
            }
        }

        public void ChangeStatus(string id, string statusId)
        {
            _bookRepository.ChangeStatus(id, statusId);
        }

        public void RentBook(string id, string userId)
        {
            _bookRepository.RentBook(id, userId);
        }

        public async Task<IEnumerable<BookStatusViewModel>> GetBookStatuses()
        {
            return await _bookRepository.GetBookStatuses();
        }

        public async Task<IEnumerable<BookedEntityViewModel>> GetBookedEntities()
        {
            return await _bookRepository.GetBookedEntities();
        }
    }
}
