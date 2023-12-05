namespace SocialMedia.DataAccess.Abstract
{
    public interface IFollowerRepository
    {
        Task<bool> FollowUser(Guid followerUserId, Guid followingUserId);

        Task<bool> UnFollowUser(Guid followerUserId, Guid followingUserId);
    }
}