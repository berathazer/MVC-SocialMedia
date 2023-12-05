using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {
        public Task<bool> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}