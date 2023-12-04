using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Entities
{
    public class Post
    {
        public Post()
        {
            PostDate = DateTimeOffset.Now;
        }

        [Key]
        public Guid PostID { get; set; }

        [Required]
        public required Guid UserID { get; set; }

        [Required(ErrorMessage = "PostContent alanı zorunludur.")]
        public required string PostContent { get; set; }
        public string? MediaType { get; set; }
        public string? MediaURL { get; set; }

        public DateTimeOffset PostDate { get; set; }

        // postu paylaşan useri gösterir.
        public User? User { get; set; }

        // postun yorumlarını gösterir.
        public List<Comment>? Comments { get; set; }
        // postu alıntı yapan kişileri gösterir.
        public List<Follower>? Reposts { get; set; }

        //postun beğenileri
        public List<Like>? Likes { get; set; }
    }
}