namespace SocialMedia.DataAccess.Abstract
{
    public interface ICommentRepository
    {
        Task<bool> Create(Guid postId, Guid userId, string commentText);

        Task<bool> Delete(Guid id);
    }
}