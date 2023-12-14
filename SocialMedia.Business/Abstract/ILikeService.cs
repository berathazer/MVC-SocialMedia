
using SocialMedia.Entities;

namespace SocialMedia.Business.Abstract
{
    public interface ILikeService
    {
        Task<bool> Create(Guid postId, Guid userId);

        Task<bool> Delete(Guid id);

        Task<List<Like>> GetUserLikes(Guid userId);
    }
}