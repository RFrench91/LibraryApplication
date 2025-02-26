namespace library_app.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
    }
}