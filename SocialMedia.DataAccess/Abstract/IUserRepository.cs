
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {

        Task<User?> GetUserByEmailOrUsername(string credential);


    }
}