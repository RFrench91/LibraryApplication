// filepath: /Users/richardfrench/Documents/git/library-app/server/Data/LibraryContext.cs
using Microsoft.EntityFrameworkCore;
using library_app.Models;
using System.Collections.Generic;

namespace library_app.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Precomputed hash for the password "password"
            string hashedPassword = "$2a$11$7QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8QJ8";

            // Seed initial data with static values
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Password = hashedPassword, Role = "Customer" },
                new User { Id = 2, Username = "user2", Password = hashedPassword, Role = "Customer" },
                new User { Id = 3, Username = "user3", Password = hashedPassword, Role = "Customer" },
                new User { Id = 4, Username = "user4", Password = hashedPassword, Role = "Customer" },
                new User { Id = 5, Username = "user5", Password = hashedPassword, Role = "Customer" },
                new User { Id = 6, Username = "user6", Password = hashedPassword, Role = "Customer" },
                new User { Id = 7, Username = "user7", Password = hashedPassword, Role = "Customer" },
                new User { Id = 8, Username = "user8", Password = hashedPassword, Role = "Customer" },
                new User { Id = 9, Username = "user9", Password = hashedPassword, Role = "Customer" },
                new User { Id = 10, Username = "user10", Password = hashedPassword, Role = "Customer" }
            };

            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Author = "Author 1", ISBN = "1234567890123", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", ISBN = "1234567890124", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 3, Title = "Book 3", Author = "Author 3", ISBN = "1234567890125", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 4, Title = "Book 4", Author = "Author 4", ISBN = "1234567890126", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 5, Title = "Book 5", Author = "Author 5", ISBN = "1234567890127", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 6, Title = "Book 6", Author = "Author 6", ISBN = "1234567890128", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 7, Title = "Book 7", Author = "Author 7", ISBN = "1234567890129", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 8, Title = "Book 8", Author = "Author 8", ISBN = "1234567890130", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 9, Title = "Book 9", Author = "Author 9", ISBN = "1234567890131", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 10, Title = "Book 10", Author = "Author 10", ISBN = "1234567890132", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 11, Title = "Book 11", Author = "Author 11", ISBN = "1234567890133", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 12, Title = "Book 12", Author = "Author 12", ISBN = "1234567890134", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 13, Title = "Book 13", Author = "Author 13", ISBN = "1234567890135", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 14, Title = "Book 14", Author = "Author 14", ISBN = "1234567890136", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 15, Title = "Book 15", Author = "Author 15", ISBN = "1234567890137", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 16, Title = "Book 16", Author = "Author 16", ISBN = "1234567890138", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 17, Title = "Book 17", Author = "Author 17", ISBN = "1234567890139", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 18, Title = "Book 18", Author = "Author 18", ISBN = "1234567890140", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 19, Title = "Book 19", Author = "Author 19", ISBN = "1234567890141", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" },
                new Book { Id = 20, Title = "Book 20", Author = "Author 20", ISBN = "1234567890142", PublishedDate = new DateTime(2020, 1, 1), Genre = "Fiction" }
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}