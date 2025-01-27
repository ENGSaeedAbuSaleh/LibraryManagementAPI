using LibraryManagement.BusinessLogic;
using LibraryManagement.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController()
        {
            _service = new BookService();
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _service.GetBooks();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _service.AddBook(book);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            _service.UpdateBook(book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok();
        }
    }
}
