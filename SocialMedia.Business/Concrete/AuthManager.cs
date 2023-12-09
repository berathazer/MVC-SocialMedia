
using SocialMedia.Entities;

namespace SocialMedia.Business.Abstract
{
    using BCrypt.Net;
    using SocialMedia.DataAccess.Abstract;

    public class AuthManager : IAuthService
    {
        private IUserRepository _userRepository;

        public AuthManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User?> LoginUser(string credential, string password)
        {
            //gelen parametreleri kontrol et
            //passwordu hashle

            var user = await _userRepository.GetUserByEmailOrUsername(credential);

            //user bulunamamıştır gerekli mesajı yazdırırız.
            if (user == null)
            {
                return null;
            }

            var IsPasswordValid = BCrypt.EnhancedVerify(password,user.Password);

            if (!IsPasswordValid)
            {
                //şifre yanlış mesajı döndürülebilir.
                return null;
            }

            return user;
        }

        public async Task<bool> RegisterUser(User user)
        {
            //gelen modeli kontrol et

            //passwordu hashle
            user.Password = BCrypt.EnhancedHashPassword(user.Password);

            //dataAccese ulaş ve yeni kullanıcıyı oluştur ve sonucu döndür.
            return await _userRepository.Create(user);


        }
    }
}