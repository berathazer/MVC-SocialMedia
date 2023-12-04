
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
      
        User GetUserByEmailOrUsername(string credential);

    
    }
}