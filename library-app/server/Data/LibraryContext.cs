using library_app.Models;
using Microsoft.EntityFrameworkCore;

namespace library_app.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Checkouts)
                .WithOne(c => c.Book)
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Checkouts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}