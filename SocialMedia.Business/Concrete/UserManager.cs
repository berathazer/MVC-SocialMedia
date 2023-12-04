

using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.DataAccess.Concrete;
using SocialMedia.Entities;

namespace SocialMedia.Business.Concrete
{
    public class UserManager : IUserService
    {

        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            var _users = _userRepository.GetAll();

            return _users;
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmailOrUsername(string credential)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}