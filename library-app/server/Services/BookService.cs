using library_app.Data;
using library_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_app.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books
            .Include(b => b.Checkouts)
            .Include(b => b.Reviews)
            .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
            .Include(b => b.Checkouts)
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.Id == id);
        }

          public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(book.Id))
            {
                throw new KeyNotFoundException("Book not found.");
            }
            else
            {
                throw;
            }
        }

        return book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            throw new KeyNotFoundException("Book not found.");
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.Id == id);
    }

        public async Task<bool> IsBookAvailableAsync(int id)
        {
            var book = await _context.Books.Include(b => b.Checkouts).FirstOrDefaultAsync(b => b.Id == id);
            return book?.IsAvailable ?? false;
        }

        public async Task<Checkout> CheckoutBookAsync(int bookId, int userId)
        {
            var book = await _context.Books.Include(b => b.Checkouts).FirstOrDefaultAsync(b => b.Id == bookId);
            if (book == null || !book.IsAvailable)
            {
                throw new InvalidOperationException("Book is not available.");
            }

            var checkout = new Checkout
            {
                BookId = bookId,
                UserId = userId,
                CheckoutDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(5) // Example: 2 weeks due date
            };
            
            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();

            checkout = await _context.Checkouts
                .Include(c => c.Book)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == checkout.Id);

            return checkout;
        }

   public async Task<List<Checkout>> GetCheckedOutBooksAsync()
    {
        return await _context.Checkouts
            .Include(c => c.Book)
            .Include(c => c.User)
            .Where(c => c.ReturnDate == null)
            .ToListAsync();
    }

    public async Task<List<Checkout>> GetCheckedOutBooksByUserAsync(int userId)
    {
        return await _context.Checkouts
            .Include(c => c.Book)
            .Include(c => c.User)
            .Where(c => c.UserId == userId && c.ReturnDate == null)
            .ToListAsync();
    }

    public async Task ReturnBookAsync(int checkoutId)
    {
        var checkout = await _context.Checkouts.FindAsync(checkoutId);
        if (checkout == null)
        {
            throw new InvalidOperationException("Checkout not found.");
        }

        checkout.ReturnDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

        public async Task AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int bookId)
        {
            return await _context.Reviews.Include(r => r.User).Where(r => r.BookId == bookId).ToListAsync();
        }
    }
}