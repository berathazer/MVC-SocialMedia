using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Follower
    {
        public Follower()
        {
            FollowDate = DateTimeOffset.Now;
        }
        [Key]
        public Guid FollowerID { get; set; }
        public Guid FollowerUserID { get; set; }
        public Guid FollowingUserID { get; set; }
        public DateTimeOffset FollowDate { get; set; }

        // Follower kaydı alındığında FollowerUser => takip isteğini gönderen kullanıcı temsil eder.
        public required User FollowerUser { get; set; }

        // Follower kaydı alındığında FollowingUser => takip isteğini alan kullanıcıyı temsil eder.
        public required User FollowingUser { get; set; }
    }
}