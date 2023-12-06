
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.Business.Abstract
{
    
    public interface IUserService: IRepository<User>
    {
        User GetUserByEmailOrUsername(string credential);

        Task<User> Authenticate(string credential, string password);
    }
}