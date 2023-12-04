using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Entities
{
    public class Like
    {
        public Like(){
            LikeDate = DateTimeOffset.Now;
        }

        [Key]
        public Guid LikeID { get; set; }
        public Guid UserID { get; set; }
        public Guid PostID { get; set; }
        public DateTimeOffset LikeDate { get; set; }

        
        //postu beğenen kullanıcıyı belirtir
        public required User User { get; set; }
        //kullanıcının beğendiği postu belirtir
        public required Post Post { get; set; }
    }
}