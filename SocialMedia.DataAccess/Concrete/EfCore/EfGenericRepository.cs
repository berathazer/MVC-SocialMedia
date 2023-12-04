using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public class EfGenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {
        public bool Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new TContext())
            {
                var entity = context.Set<TEntity>().Find(id);

                if (entity == null)
                    return false;

                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var context = new TContext())
            {
                TEntity? entity = context.Set<TEntity>().Find(id);

                if(entity == null)
                {
                    throw new InvalidOperationException("Belirtilen ID'ye sahip kayıt bulunamadı.");
                }
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}