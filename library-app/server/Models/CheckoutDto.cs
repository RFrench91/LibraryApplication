namespace library_app.Models.Dto
{
    public class CheckoutDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Username { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}