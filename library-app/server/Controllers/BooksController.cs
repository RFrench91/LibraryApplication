using Microsoft.AspNetCore.Mvc;
using library_app.Models;
using library_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks([FromQuery] string title, [FromQuery] string author)
        {
            var books = await _bookService.GetBooksAsync();

            if (!string.IsNullOrEmpty(title))
            {
                books = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(author))
            {
                books = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(books);
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<Book>>> GetRandomBooks([FromQuery] int count = 5)
        {
            var books = await _bookService.GetBooksAsync();
            books = books.OrderBy(b => Guid.NewGuid()).Take(count).ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("{id}/availability")]
        public async Task<ActionResult<bool>> IsBookAvailable(int id)
        {
            var isAvailable = await _bookService.IsBookAvailableAsync(id);
            return Ok(isAvailable);
        }

        [HttpPost("{id}/checkout")]
        public async Task<ActionResult<Checkout>> CheckoutBook(int id, [FromBody] int userId)
        {
            try
            {
                var checkout = await _bookService.CheckoutBookAsync(id, userId);
                return Ok(checkout);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("checkedout")]
        public async Task<ActionResult<IEnumerable<Checkout>>> GetCheckedOutBooks()
        {
            var checkouts = await _bookService.GetCheckedOutBooksAsync();
            return Ok(checkouts);
        }

        [HttpGet("checkedout/{userId}")]
        public async Task<ActionResult<IEnumerable<Checkout>>> GetCheckedOutBooksByUser(int userId)
        {
            var checkouts = await _bookService.GetCheckedOutBooksByUserAsync(userId);
            return Ok(checkouts);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromBody] int checkoutId)
        {
            try
            {
                await _bookService.ReturnBookAsync(checkoutId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}