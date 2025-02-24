using System;

namespace library_app.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}