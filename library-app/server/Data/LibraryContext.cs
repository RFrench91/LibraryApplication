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
        }
    }
}