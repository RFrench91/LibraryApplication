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
            return await _context.Books.Include(b => b.Checkouts).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Checkouts).FirstOrDefaultAsync(b => b.Id == id);
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
                CheckoutDate = DateTime.UtcNow
            };
            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();

            return checkout;
        }

        public async Task<IEnumerable<Checkout>> GetCheckedOutBooksAsync()
        {
            return await _context.Checkouts.Include(c => c.Book).Include(c => c.User).ToListAsync();
        }

        public async Task<IEnumerable<Checkout>> GetCheckedOutBooksByUserAsync(int userId)
        {
            return await _context.Checkouts.Include(c => c.Book).Where(c => c.UserId == userId).ToListAsync();
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
    }
}