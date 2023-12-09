
using System.ComponentModel.DataAnnotations;

namespace SocialMedia.WebUI.Models.Auth
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Kimlik bilgileri boş olamaz.")]
        [MinLength(6, ErrorMessage = "Kimlik bilgileri en az 6 karakterden oluşmalı.")]
        public required string Credential { get; set; }

        [Required(ErrorMessage = "Şifre boş olamaz.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterden oluşmalı.")]
        public required string Password { get; set; }
    }
}