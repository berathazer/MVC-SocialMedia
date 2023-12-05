

using Microsoft.EntityFrameworkCore;
using SocialMedia.DataAccess.Abstract;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete
{
    public class EfUserRepository : IUserRepository
    {

        public async Task<bool> Create(User entity)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new AppDbContext())
            {
                var userToDelete = context.Users.Find(id);
                if (userToDelete == null)
                    return false;

                context.Users.Remove(userToDelete);
                context.SaveChanges();
                return true;
            }
        }

        public async Task<User?> Update(User entity)
        {
            using (var context = new AppDbContext())
            {
                var existingUser = context.Users.Find(entity.UserID);
                if (existingUser == null)
                {
                    return null;
                }

                existingUser.FullName = entity.FullName;
                existingUser.Username = entity.Username;
                existingUser.Email = entity.Email;
                existingUser.Password = entity.Password;

                await context.SaveChangesAsync();
                return existingUser;
            }
        }

        public List<User> GetAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Users.ToList();
            }
        }

        public User GetById(Guid id)
        {
            using (var context = new AppDbContext())
            {
                return context.Users.Find(id);
            }
        }

        public async Task<User> GetUserByEmailOrUsername(string credential)
        {
            using (var context = new AppDbContext())
            {
                var _user = await context.Users.FirstOrDefaultAsync(u => u.Email == credential || u.Username == credential);

                if (_user != null)
                {
                    return _user;
                }

                return null;
            }
        }
    }
}