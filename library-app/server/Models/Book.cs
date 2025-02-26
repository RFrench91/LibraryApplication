using System;
using System.Collections.Generic;
using System.Linq;

namespace library_app.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public bool IsAvailable => !Checkouts.Any(c => c.ReturnDate == null);
        public double AverageRating => Reviews.Any() ? Reviews.Average(r => r.Rating) : 0;
    }
}