
namespace SocialMedia.DataAccess.Abstract
{
    public interface IRepostRepository
    {
        Task<bool> Create(Guid originalPostId, Guid userId);

        Task<bool> Delete(Guid id);
        
    }
}