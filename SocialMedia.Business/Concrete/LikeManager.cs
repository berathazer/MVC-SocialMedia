

using SocialMedia.Business.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.Business.Concrete
{
    public class LikeManager : ILikeService
    {
        public Task<bool> Create(Guid postId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Like>> GetUserLikes(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}