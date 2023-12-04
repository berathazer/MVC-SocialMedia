using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Repost
    {

        public Repost(){
            RepostDate = DateTimeOffset.Now;
        }
        [Key]
        public Guid RepostID { get; set; }
        public Guid UserID { get; set; }
        public Guid OriginalPostID { get; set; }
        public DateTimeOffset RepostDate { get; set; }

        // repost yapan kullanıcıyı belirtir.
        public required User User { get; set; }
        // alıntı yapılan postu belirtir.
        public required Post OriginalPost { get; set; }

        public List<Comment>? RepostComments { get; set; }
    }
}