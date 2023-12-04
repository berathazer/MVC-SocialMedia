using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Repost
    {

        public Repost()
        {
            RepostDate = DateTimeOffset.Now;
        }
        [Key]
        public Guid RepostID { get; set; }
        [Required]
        public required Guid UserID { get; set; }
        [Required]
        public required Guid OriginalPostID { get; set; }
        public DateTimeOffset RepostDate { get; set; }

        // repost yapan kullanıcıyı belirtir.
        public User? User { get; set; }
        // alıntı yapılan postu belirtir.
        public Post? OriginalPost { get; set; }

        public List<Comment>? RepostComments { get; set; }
    }
}