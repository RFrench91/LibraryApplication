// filepath: /Users/richardfrench/Documents/git/library-app/server/Models/User.cs
using System.ComponentModel.DataAnnotations;

namespace library_app.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}