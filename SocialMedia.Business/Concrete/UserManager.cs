using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
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

        public async Task<bool> Create(User entity)
        {
            return await _userRepository.Create(entity);
        }

        public bool Delete(Guid id)
        {
            return _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public async Task<User?> GetUserByEmailOrUsername(string credential)
        {
            return await _userRepository.GetUserByEmailOrUsername(credential);
        }

        public Task<User?> Update(User entity)
        {
            return _userRepository.Update(entity);
        }


    }
}