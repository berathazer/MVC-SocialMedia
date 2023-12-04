using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Entities
{
    public class Follower
    {
        public Follower()
        {
            FollowDate = DateTimeOffset.Now;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FollowerID { get; set; }
        [Required]
        public required Guid FollowerUserID { get; set; }
        [Required]
        public required Guid FollowingUserID { get; set; }
        public DateTimeOffset FollowDate { get; set; }

        // Follower kaydı alındığında FollowerUser => takip isteğini gönderen kullanıcı temsil eder.
        public User? FollowerUser { get; set; }

        // Follower kaydı alındığında FollowingUser => takip isteğini alan kullanıcıyı temsil eder.
        public User? FollowingUser { get; set; }
    }
}