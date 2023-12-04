

using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public User Update(User entity)
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

        
    }
}