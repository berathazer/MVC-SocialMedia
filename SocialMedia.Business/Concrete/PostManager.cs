

using Azure;
using SocialMedia.Business.Abstract;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> Create(Post entity)
        {
            return await _postRepository.Create(entity);
        }

        public bool Delete(Guid id)
        {
            return _postRepository.Delete(id);
        }

        public List<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post? GetById(Guid id)
        {
            return _postRepository.GetById(id);
        }

        public Task<Post?> Update(Post entity)
        {
            return _postRepository.Update(entity);
        }
    }
}