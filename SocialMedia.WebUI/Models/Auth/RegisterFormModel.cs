using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SocialMedia.WebUI.Models.Auth
{
    public class RegisterFormModel
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı zorunludur.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı zorunludur.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}