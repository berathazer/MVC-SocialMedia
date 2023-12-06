using Microsoft.EntityFrameworkCore;
using SocialMedia.Entities;

namespace SocialMedia.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {




        public static async Task Seed()
        {

            var context = new AppDbContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {



                if (context.Users.Count() == 0)
                {
                    await context.Users.AddRangeAsync(Users);
                    await context.SaveChangesAsync();

                }

                if (context.Posts.Count() == 0)
                {
                    var _Users = await context.Users.ToListAsync();
                    Post[] Posts = {
                        new Post(){

                            PostContent="Bu bir deneme postudur",
                            UserID=_Users[0].UserID
                        },
                        new Post(){

                            PostContent="Bberatag ahsdhu bir deneme postudur",
                            UserID=_Users[0].UserID
                        },
                        new Post(){

                            PostContent="Burcu ahsdhu bir deneme postudur",
                            UserID=_Users[1].UserID
                        },
                        new Post(){

                            PostContent="Burcununasfd ahsdhu bir deneme postudur",
                            UserID=_Users[1].UserID
                        }
                    };
                    await context.Posts.AddRangeAsync(Posts);

                    await context.SaveChangesAsync();


                }


                if (context.Reposts.Count() == 0)
                {

                    var _Users = await context.Users.ToListAsync();
                    var _Posts = await context.Posts.ToListAsync();
                    Repost[] Reposts ={
                        new Repost(){

                                OriginalPostID = _Posts[0].PostID,
                                UserID=_Users[2].UserID
                            },
                        new Repost(){

                                OriginalPostID = _Posts[1].PostID,
                                UserID=_Users[2].UserID
                            }
                    };

                    await context.Reposts.AddRangeAsync(Reposts);
                    await context.SaveChangesAsync();

                }


                if (context.Likes.Count() == 0)
                {
                    var _Users = await context.Users.ToListAsync();
                    var _Posts = await context.Posts.ToListAsync();
                    Like[] Likes = {
                        new Like()
                            {

                                UserID = _Users[2].UserID,
                                PostID = _Posts[0].PostID
                            },
                        new Like()
                            {

                                UserID = _Users[1].UserID,
                                PostID = _Posts[0].PostID
                            }

                        };

                    await context.Likes.AddRangeAsync(Likes);
                    await context.SaveChangesAsync();

                }


                if (context.Followers.Count() == 0)
                {
                    var _Users = await context.Users.ToListAsync();
                    var _Posts = await context.Posts.ToListAsync();
                    await context.Followers.AddAsync(
                        new Follower()
                        {
                            FollowerUserID = _Users[0].UserID,
                            FollowingUserID = _Posts[1].UserID
                        }
                    );
                    await context.SaveChangesAsync();

                }

                if (context.Comments.Count() == 0)
                {
                    var _Users = await context.Users.ToListAsync();
                    var _Posts = await context.Posts.ToListAsync();
                    await context.Comments.AddAsync(
                        new Comment()
                        {
                            CommentText = "ooo ilk mesajı atmayan adam adammıdır.",
                            UserID = _Users[1].UserID,
                            PostID = _Posts[0].PostID
                        }
                    );

                }



                await context.SaveChangesAsync();

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






    }
}