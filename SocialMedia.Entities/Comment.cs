using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Comment
    {   
        [Key]
        public Guid CommentID { get; set; }
        public Guid PostID { get; set; }
        public Guid UserID { get; set; }
        public required string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        // yorum yapılan postu gösterir.
        public required Post Post { get; set; }

        // yorum yapan kullanıcıyı gösterir.
        public required User User { get; set; }
    }
}