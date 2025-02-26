using Microsoft.AspNetCore.Mvc;
using library_app.Models;
using library_app.Models.Dto;
using library_app.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace library_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks([FromQuery] string? title, [FromQuery] string? author, [FromQuery] bool? available)
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

            if (available.HasValue)
            {
                books = books.Where(b => b.IsAvailable == available.Value).ToList();
            }

            var bookDtos = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublishedDate = b.PublishedDate,
                Genre = b.Genre,
                IsAvailable = b.IsAvailable,
                AverageRating = b.AverageRating
            }).ToList();

            return Ok(bookDtos);
        }

        [HttpGet("random")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetRandomBooks([FromQuery] int count = 5)
        {
            var books = await _bookService.GetBooksAsync();
            books = books.OrderBy(b => Guid.NewGuid()).Take(count).ToList();

            var bookDtos = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublishedDate = b.PublishedDate,
                Genre = b.Genre,
                IsAvailable = b.IsAvailable,
                AverageRating = b.AverageRating
            }).ToList();

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                AverageRating = book.AverageRating
            };

            return Ok(bookDto);
        }

        [HttpGet("{id}/availability")]
        public async Task<ActionResult<bool>> IsBookAvailable(int id)
        {
            var isAvailable = await _bookService.IsBookAvailableAsync(id);
            return Ok(isAvailable);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book)
        {
            var addedBook = await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new { id = addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedBook = await _bookService.UpdateBookAsync(book);
                return Ok(updatedBook);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{id}/checkout")]
        public async Task<ActionResult<CheckoutDto>> CheckoutBook(int id, [FromBody] CheckoutRequestDto request)
        {
            try
            {
                if (request.UserId == null)
                {
                    return BadRequest("User ID is required.");
                }
                var checkout = await _bookService.CheckoutBookAsync(id, request.UserId);
                var checkoutDto = new CheckoutDto
                {
                    Id = checkout.Id,
                    BookTitle = checkout.Book.Title,
                    Username = checkout.User.UserName,
                    CheckoutDate = checkout.CheckoutDate,
                    DueDate = checkout.DueDate
                };

                return Ok(checkoutDto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpGet("checkedout")]
        public async Task<ActionResult<IEnumerable<CheckoutDto>>> GetCheckedOutBooks()
        {
            var checkouts = await _bookService.GetCheckedOutBooksAsync();
            var checkoutDtos = checkouts.Select(c => new CheckoutDto
            {
                Id = c.Id,
                BookTitle = c.Book.Title,
                Username = c.User.UserName,
                CheckoutDate = c.CheckoutDate,
                DueDate = c.DueDate
            }).ToList();

            return Ok(checkoutDtos);
        }

        [HttpGet("checkedout/{userId}")]
        public async Task<ActionResult<IEnumerable<CheckoutDto>>> GetCheckedOutBooksByUser(string userId)
        {
            var checkouts = await _bookService.GetCheckedOutBooksByUserAsync(userId);
            var checkoutDtos = checkouts.Select(c => new CheckoutDto
            {
                Id = c.Id,
                BookTitle = c.Book.Title,
                Username = c.User.UserName,
                CheckoutDate = c.CheckoutDate,
                DueDate = c.DueDate
            }).ToList();

            return Ok(checkoutDtos);
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

        [HttpPost("{id}/reviews")]
        public async Task<ActionResult<ReviewDto>> AddReview(int id, [FromBody] ReviewDto reviewDto)
        {
            var review = new Review
            {
                BookId = id,
                UserId = reviewDto.UserId,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                 CreatedAt = DateTime.UtcNow
            };

            await _bookService.AddReviewAsync(review);

            reviewDto.Id = review.Id;
            reviewDto.CreatedAt = review.CreatedAt;

            return Ok(reviewDto);
        }

        [HttpGet("{id}/reviews")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(int id)
        {
            var reviews = await _bookService.GetReviewsAsync(id);

            var reviewDtos = reviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                BookId = r.BookId,
                UserId = r.UserId,
                Username = r.User.UserName,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList();

            return Ok(reviewDtos);
        }
    }
}