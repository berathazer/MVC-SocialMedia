using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        public async Task<bool> Create(Post entity)
        {

            using (var context = new AppDbContext())
            {
                context.Posts.Add(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new AppDbContext())
            {
                var post = context.Posts.Find(id);

                if (post == null) return false;

                context.Posts.Remove(post);
                context.SaveChanges();
                return true;
            }
        }


        public List<Post> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Posts.ToList();
            }
        }

        public Post? GetById(Guid id)
        {
            using (var context = new AppDbContext())
            {
                return context.Posts.Find(id);
            }
        }

        public async Task<Post?> Update(Post entity)
        {
            using (var context = new AppDbContext())
            {
                var existingPost = await context.Posts.FindAsync(entity.PostID);

                if (existingPost == null) return null;

                existingPost.PostContent = entity.PostContent;
                existingPost.MediaType = entity.MediaType;
                existingPost.MediaURL = entity.MediaURL;

                await context.SaveChangesAsync();
                return existingPost;

            }
        }
    }
}