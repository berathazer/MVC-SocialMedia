namespace SocialMedia.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        T GetById(Guid id);

        List<T> GetAll();

        Task<bool> Create(T entity);

        bool Delete(Guid id);

        Task<T?> Update(T entity);

    }
}