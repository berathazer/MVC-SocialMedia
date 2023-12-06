
using SocialMedia.Entities;

namespace SocialMedia.Business.Abstract
{
    //login - register işlemleri burda yapılacak.
    public interface IAuthService
    {
        Task<bool> RegisterUser(User user);

        Task<User?> LoginUser(string credential, string password);

    }
}