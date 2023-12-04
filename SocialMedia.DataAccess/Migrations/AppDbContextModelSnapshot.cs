﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMedia.DataAccess;

#nullable disable

namespace SocialMedia.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialMedia.Entities.Comment", b =>
                {
                    b.Property<Guid>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RepostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("RepostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialMedia.Entities.Follower", b =>
                {
                    b.Property<Guid>("FollowerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("FollowDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FollowerUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowerID");

                    b.HasIndex("FollowerUserID");

                    b.HasIndex("FollowingUserID");

                    b.HasIndex("PostID");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("SocialMedia.Entities.Like", b =>
                {
                    b.Property<Guid>("LikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("LikeDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikeID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SocialMedia.Entities.Post", b =>
                {
                    b.Property<Guid>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("PostDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SocialMedia.Entities.Repost", b =>
                {
                    b.Property<Guid>("RepostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OriginalPostID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("RepostDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RepostID");

                    b.HasIndex("OriginalPostID");

                    b.HasIndex("UserID");

                    b.ToTable("Reposts");
                });

            modelBuilder.Entity("SocialMedia.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialMedia.Entities.Comment", b =>
                {
                    b.HasOne("SocialMedia.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Repost", null)
                        .WithMany("RepostComments")
                        .HasForeignKey("RepostID");

                    b.HasOne("SocialMedia.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Follower", b =>
                {
                    b.HasOne("SocialMedia.Entities.User", "FollowerUser")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.User", "FollowingUser")
                        .WithMany()
                        .HasForeignKey("FollowingUserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.Post", null)
                        .WithMany("Reposts")
                        .HasForeignKey("PostID");

                    b.Navigation("FollowerUser");

                    b.Navigation("FollowingUser");
                });

            modelBuilder.Entity("SocialMedia.Entities.Like", b =>
                {
                    b.HasOne("SocialMedia.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Post", b =>
                {
                    b.HasOne("SocialMedia.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Repost", b =>
                {
                    b.HasOne("SocialMedia.Entities.Post", "OriginalPost")
                        .WithMany()
                        .HasForeignKey("OriginalPostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialMedia.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OriginalPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialMedia.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Reposts");
                });

            modelBuilder.Entity("SocialMedia.Entities.Repost", b =>
                {
                    b.Navigation("RepostComments");
                });

            modelBuilder.Entity("SocialMedia.Entities.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Likes");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
