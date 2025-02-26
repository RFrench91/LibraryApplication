using System;

namespace library_app.Models.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public double AverageRating { get; set; }
    }
}