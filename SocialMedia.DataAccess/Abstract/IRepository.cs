namespace SocialMedia.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(Guid id);

        List<T> GetAll();

        bool Create(T entity);

        bool Delete(Guid id);

        T Update(T entity);

    }
}