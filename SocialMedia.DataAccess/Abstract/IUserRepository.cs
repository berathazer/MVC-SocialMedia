
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {

        Task<User?> GetUserByEmailOrUsername(string credential);
        Task<User?> CheckExistingUserByEmailOrUsername(string username,string email);

    }
}