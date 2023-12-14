using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Business.Abstract;

namespace SocialMedia.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        public Task<bool> Create(Guid postId, Guid userId, string commentText)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}