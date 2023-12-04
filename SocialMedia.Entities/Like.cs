using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Entities
{
    public class Like
    {
        public Like()
        {
            LikeDate = DateTimeOffset.Now;
        }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LikeID { get; set; }
        [Required]
        public required Guid UserID { get; set; }
        [Required]
        public required Guid PostID { get; set; }
        public DateTimeOffset LikeDate { get; set; }


        //postu beğenen kullanıcıyı belirtir
        public User? User { get; set; }
        //kullanıcının beğendiği postu belirtir
        public Post? Post { get; set; }
    }
}