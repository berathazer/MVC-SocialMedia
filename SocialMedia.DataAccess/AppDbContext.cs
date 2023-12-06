using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess
{
    public class AppDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=BERAA;Initial Catalog=SocialMedia;User Id=sa;Password=Berat102030;Encrypt=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //usera default olarak createdAt ve updatedAt alanlarını atadık.
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasDefaultValueSql("GETDATE()");



            //altta eklediğim alanlar ilişkilerden birinin silinmesinden sonra bir cycle oluşmasını engellemek için.
            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowingUser)
                .WithMany()  // FollowingUser için WithMany çağrısını boş bırakarak, ilişkiyi yalnızca bir yönlü yapar
                .HasForeignKey(f => f.FollowingUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostID)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Repost>()
                    .HasOne(r => r.User)
                    .WithMany(u => u.Reposts)
                    .HasForeignKey(r => r.UserID)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.NoAction);

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Follower> Followers { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DbSet<Repost> Reposts { get; set; }



    }
}