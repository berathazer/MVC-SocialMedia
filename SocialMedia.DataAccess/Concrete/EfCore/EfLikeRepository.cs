using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfLikeRepository : ILikeRepository
    {
        private readonly AppDbContext _context;

        public EfLikeRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<bool> Create(Guid postId, Guid userId)
        {
            var _like = new Like() { UserID = userId, PostID = postId };
            await _context.Likes.AddAsync(_like);
            return true;

        }

        public async Task<bool> Delete(Guid id)
        {
            var likeToDelete = await _context.Likes.FindAsync(id);

            if (likeToDelete == null) return false;

            _context.Likes.Remove(likeToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Like>> GetUserLikes(Guid userId)
        {
            return await _context.Likes.Where(l => l.UserID == userId).ToListAsync();
        }
    }
}