using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Business.Abstract
{
    public interface ICommentService
    {
        Task<bool> Create(Guid postId, Guid userId, string commentText);

        Task<bool> Delete(Guid id);
    }
}