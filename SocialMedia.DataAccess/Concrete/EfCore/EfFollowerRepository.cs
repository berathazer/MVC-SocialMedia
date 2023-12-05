
using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfFollowerRepository : IFollowerRepository
    {

        private readonly AppDbContext _context;
        public EfFollowerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> FollowUser(Guid followerUserId, Guid followingUserId)
        {
            var _follower = new Follower() { FollowerUserID = followerUserId, FollowingUserID = followingUserId };

            await _context.Followers.AddAsync(_follower);

            return true;
        }
        
        public async Task<bool> UnFollowUser(Guid followerUserId, Guid followingUserId)
        {
            try
            {
                var followerToDelete = await _context.Followers
                    .FirstOrDefaultAsync(f => f.FollowerUserID == followerUserId && f.FollowingUserID == followingUserId);

                if (followerToDelete != null)
                {
                    _context.Followers.Remove(followerToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}