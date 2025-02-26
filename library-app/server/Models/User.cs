using Microsoft.AspNetCore.Identity;

namespace library_app.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public ICollection<Checkout> Checkouts { get; set; }
    }
}