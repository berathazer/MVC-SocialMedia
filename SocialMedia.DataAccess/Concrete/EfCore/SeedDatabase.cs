using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {




        public static async Task Seed()
        {
            Like? _likes = null;

            var context = new AppDbContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {



                if (context.Users.Count() == 0)
                {
                    await context.Users.AddRangeAsync(Users);
                }

                if (context.Posts.Count() == 0)
                {
                    await context.Posts.AddRangeAsync(Posts);
                }

                if (context.Reposts.Count() == 0)
                {
                    await context.Reposts.AddRangeAsync(Reposts);
                }

                if (context.Likes.Count() == 0)
                {
                    await context.Likes.AddRangeAsync(Likes);


                }

                if (context.Followers.Count() == 0)
                {
                    await context.Followers.AddAsync(
                        new Follower()
                        {
                            FollowerUserID = Users[0].UserID,
                            FollowingUserID = Users[1].UserID
                        }
                    );
                }

                if (context.Comments.Count() == 0)
                {
                    await context.Comments.AddAsync(
                        new Comment()
                        {
                            CommentText = "ooo ilk mesajı atmayan adam adammıdır.",
                            UserID = Users[1].UserID,
                            PostID = Posts[0].PostID
                        }
                    );
                }



                await context.SaveChangesAsync();
                _likes = await context.Likes.FirstOrDefaultAsync(u => u.UserID != Guid.NewGuid());
                Console.WriteLine(_likes?.UserID);
                Console.WriteLine("Database seed successfully.");

            }
        }

        private static User[] Users = {
            new User(){

                FullName= "Berat Hazer",
                Username="berathazer",
                Email="berathazer371@gmail.com",
                Password= "Some hashed passwoarasd",

            },
            new User(){

                FullName= "Burcu Gül",
                Username="bgul10",
                Email="bgul@gmail.com",
                Password= "Some hashed passwordasd",
            },
            new User(){

                FullName= "Ahmet Tatyüz",
                Username="ahmetti",
                Email="ahmt@gmail.com",
                Password= "Some hashed passworaad",
            },
        };


        private static Post[] Posts = {
            new Post(){

                PostContent="Bu bir deneme postudur",
                UserID=Users[0].UserID
            },
            new Post(){

                PostContent="Bberatag ahsdhu bir deneme postudur",
                UserID=Users[0].UserID
            },
            new Post(){

                PostContent="Burcu ahsdhu bir deneme postudur",
                UserID=Users[1].UserID
            },
            new Post(){

                PostContent="Burcununasfd ahsdhu bir deneme postudur",
                UserID=Users[0].UserID
            }
        };

        private static Repost[] Reposts ={
              new Repost(){

                    OriginalPostID = Posts[0].PostID,
                    UserID=Users[2].UserID
                },
            new Repost(){

                    OriginalPostID = Posts[1].PostID,
                    UserID=Users[2].UserID
                }
        };

        private static Like[] Likes = {
             new Like()
                {

                    UserID = Users[2].UserID,
                    PostID = Posts[0].PostID
                },
            new Like()
                {

                    UserID = Users[1].UserID,
                    PostID = Posts[0].PostID
                }
    };




    }
}