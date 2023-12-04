using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Comment
    {
        [Key]
        public Guid CommentID { get; set; }
        [Required]
        public required Guid PostID { get; set; }
        [Required]
        public required Guid UserID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Mesaj alanı minimum 1 karakter olmalı.")]
        [MaxLength(1000, ErrorMessage = "Mesaj alanı maximum 1000 karakter olmalı.")]
        public required string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        // yorum yapılan postu gösterir.
        public Post? Post { get; set; }

        // yorum yapan kullanıcıyı gösterir.
        public User? User { get; set; }
    }
}