using System.ComponentModel.DataAnnotations;

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
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "PostContent alanı zorunludur.")]
        public required string PostContent { get; set; }
        public string? MediaType { get; set; }
        public string? MediaURL { get; set; }

        public DateTimeOffset PostDate { get; set; }

        // postu paylaşan useri gösterir.
        public required User User { get; set; }

        // postun yorumlarını gösterir.
        public List<Comment>? Comments { get; set; }
        // postu alıntı yapan kişileri gösterir.
        public List<Follower>? Reposts { get; set; }
    }
}