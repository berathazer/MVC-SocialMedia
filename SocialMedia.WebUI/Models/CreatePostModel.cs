
using System.ComponentModel.DataAnnotations;


namespace SocialMedia.WebUI.Models
{
    public class CreatePostModel
    {
        [Required(ErrorMessage = "İçerik boş bırakılamaz.")]
        [MinLength(6, ErrorMessage = "Kimlik bilgileri en az 6 karakterden oluşmalı.")]
        public required string Content { get; set; }

        [DataType(DataType.Upload)]
        public required IFormFile Media { get; set; }
    }
}
