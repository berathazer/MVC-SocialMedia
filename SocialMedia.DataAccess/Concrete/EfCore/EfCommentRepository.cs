using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public EfCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Guid postId, Guid userId, string commentText)
        {
            var comment = new Comment() { PostID = postId, UserID = userId, CommentText = commentText };
            await _context.Comments.AddAsync(comment);

            return true;

        }

        public async Task<bool> Delete(Guid id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null) return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}