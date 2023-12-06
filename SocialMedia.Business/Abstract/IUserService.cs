
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.Business.Abstract
{

    public interface IUserService : IRepository<User>
    {
        Task<User?> GetUserByEmailOrUsername(string credential);
        
    }
}