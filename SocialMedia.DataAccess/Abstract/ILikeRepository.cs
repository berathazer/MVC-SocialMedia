
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Abstract
{
    public interface ILikeRepository
    {
        Task<bool> Create(Guid postId,Guid userId);
        
        Task<bool> Delete(Guid id);

        Task<List<Like>> GetUserLikes(Guid userId);
    }
}