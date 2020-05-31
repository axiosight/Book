using Newtonsoft.Json;
using SaM.BookShelves.Common.Constants;
using SaM.BookShelves.DataProvider.Interfaces;
using SaM.BookShelves.Logic.Interfaces;
using SaM.BookShelves.Models.Entities;
using SaM.BookShelves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DeleteBookById(string id)
        {
            _bookRepository.DeleteBookById(id);
        }

        public async Task<ResponseViewModel> AddBook(AddBookViewModel model)
        {
            var bookId = Guid.NewGuid().ToString();

            var authors = JsonConvert.DeserializeObject<string[]>(model.Authors).Select(author => new Author
            {
                Id = Guid.NewGuid().ToString(),
                Name = author
            });

            var publishers = JsonConvert.DeserializeObject<string[]>(model.Publishers).Select(publisher => new Publisher
            {
                Id = Guid.NewGuid().ToString(),
                Name = publisher
            });

            var book = new Book()
            {
                Id = bookId,
                Name = model.Name,
                OriginalName = model.OriginalName,
                ISBN = model.ISBN,
                Year = model.Year,
                Description = model.Description,
                BookAuthors = authors.Select(bookAuthor => new BookAuthor
                {
                    Author = bookAuthor,
                    BookId = bookId
                }).ToList(),
                BookPublishers = publishers.Select(bookPublisher => new BookPublisher
                {
                    Publisher = bookPublisher,
                    BookId = bookId
                }).ToList(),
                Previews = new List<Preview> {new Preview
                {
                    BookId = bookId,
                    Img = Convert.FromBase64String(model.ImageUrl),
                    Extension = ConfigPreviewInitializer.Previews.Extension,
                    Type = ConfigPreviewInitializer.Previews.Type,
                    IsPreview = true,
                    Name = $"{bookId}.jpg"
                } }
            };

            if (book != null)
            {
                _bookRepository.AddBook(book);
                return new ResponseViewModel()
                {
                    Result = true,
                    Message = "Book add!"
                };
            }
            else
            {
                return new ResponseViewModel()
                {
                    Result = false,
                    Message = "Book not add!"
                };
            }
        }
    }
}
