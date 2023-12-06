using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.Business.Concrete
{
    using BCrypt.Net;

    public class UserManager : IUserService
    {

        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Authenticate(string credential, string password)
        {
            // Kullanıcı doğrulama işlemi
            // Gerekirse parola kontrolü ve diğer gerekli işlemler burada yapılabilir
            throw new NotImplementedException();
        }


        public async Task<bool> Create(User entity)
        {

            // Kullanıcıyı veritabanına ekleme işlemi
            // Gerekirse parola hashleme ve diğer gerekli işlemler burada yapılabilir

            //şifreyi hashle ve yeni kullanıcı oluştur.
            entity.Password = BCrypt.EnhancedHashPassword(entity.Password);
            var res = await _userRepository.Create(entity);

            if (!res)
            {
                return false;
            }

            return true;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmailOrUsername(string credential)
        {
            throw new NotImplementedException();
        }

        public Task<User?> Update(User entity)
        {
            throw new NotImplementedException();
        }

    }
}