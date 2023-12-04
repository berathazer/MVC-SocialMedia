using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "FullName alanı zorunludur.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Username alanı zorunludur.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password alanı zorunludur.")]
        public required string Password { get; set; }

        //kullanıcının takipçilerini gösterir
        public List<Follower>? Followers { get; set; }

        //kullanıcının postlarını gösterir
        public List<Post>? Posts { get; set; }
    }
}