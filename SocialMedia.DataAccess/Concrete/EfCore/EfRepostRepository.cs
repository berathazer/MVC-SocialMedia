
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfRepostRepository : IRepostRepository
    {
        private readonly AppDbContext _context;

        public EfRepostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Guid originalPostId, Guid userId)
        {
            var _repost = new Repost() { OriginalPostID = originalPostId, UserID = userId };
            await _context.Reposts.AddAsync(_repost);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var repostToDelete = await _context.Reposts.FindAsync(id);

            if (repostToDelete == null) return false;

            _context.Reposts.Remove(repostToDelete);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}