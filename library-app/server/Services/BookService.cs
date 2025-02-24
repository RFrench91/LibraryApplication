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

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> IsBookAvailableAsync(int bookId)
        {
            return !await _context.Checkouts.AnyAsync(c => c.BookId == bookId && !c.IsReturned);
        }

        public async Task<Checkout> CheckoutBookAsync(int bookId, int userId)
        {
            if (!await IsBookAvailableAsync(bookId))
            {
                throw new InvalidOperationException("Book is not available.");
            }

            var checkout = new Checkout
            {
                BookId = bookId,
                UserId = userId,
                CheckoutDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(5),
                IsReturned = false
            };

            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();

            return checkout;
        }

        public async Task<List<Checkout>> GetCheckedOutBooksAsync()
        {
            return await _context.Checkouts.Include(c => c.Book).Include(c => c.User).Where(c => !c.IsReturned).ToListAsync();
        }

        public async Task<List<Checkout>> GetCheckedOutBooksByUserAsync(int userId)
        {
            return await _context.Checkouts.Include(c => c.Book).Where(c => c.UserId == userId && !c.IsReturned).ToListAsync();
        }

        public async Task ReturnBookAsync(int checkoutId)
        {
            var checkout = await _context.Checkouts.FindAsync(checkoutId);
            if (checkout == null)
            {
                throw new InvalidOperationException("Checkout not found.");
            }

            checkout.IsReturned = true;
            await _context.SaveChangesAsync();
        }
    }
}