using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaM.BookShelves.Common.Routes;
using SaM.BookShelves.Logic.Interfaces;

namespace SaM.BookShelves.WebApi.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet(RoutesApi.Book.GetAllBooks)]
        public async Task<IActionResult> GetAllBooks()
        {
            var res = await _bookService.GetAllBooks();

            return Ok(res);
        }

        [HttpPost(RoutesApi.Book.GetSearchBooks)]
        public async Task<IActionResult> GetSearchBooks([FromForm] string tagSearch, [FromForm] string termSearch)
        {
            var res = await _bookService.GetSearchBooks(tagSearch, termSearch);

            return Ok(res);
        }

        [HttpPost("api/book/{id}/status/{statusId}")]
        public IActionResult ChangeStatus(string id, string statusId)
        {
            _bookService.ChangeStatus(id, statusId);
            return Ok();
        }

        [HttpPost("api/book/{id}/user/{userId}")]
        public IActionResult RentBook(string id, string userId)
        {
            _bookService.RentBook(id, userId);
            return Ok();
        }

        [HttpGet("api/book/statuses")]
        public async Task<IActionResult> GetBookStatuses()
        {
            var statuses = await _bookService.GetBookStatuses();
            return Ok(statuses);
        }

        [HttpGet("api/book/booked")]
        public async Task<IActionResult> GetBookedEntities()
        {
            var entities = await _bookService.GetBookedEntities();
            return Ok(entities);
        }
    }
}