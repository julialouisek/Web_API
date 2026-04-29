using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection.Emit;

namespace Web_API.Models
{
    public class WebAPIDbContext : DbContext
    {
        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options) : base(options)
        {

        }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }


        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name = "Alice Johnson", Phone = "+1-555-0101" },
                new User() { Id = 2, Name = "Bob Martinez", Phone = "+1-555-0202" },
                new User() { Id = 3, Name = "Clara Nguyen", Phone = "+44-7700-900303" },
                new User() { Id = 4, Name = "David Okonkwo", Phone = "+46-70-440-0404" },
                new User() { Id = 5, Name = "Eva Lindström", Phone = "+46-73-550-0505" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest() { Id = 1, Name = "Photography", Description = "Capturing moments through a camera lens, from landscape to portrait photography." },
                new Interest() { Id = 2, Name = "Hiking", Description = "Exploring nature trails and mountains on foot, enjoying the outdoors." },
                new Interest() { Id = 3, Name = "Video Games", Description = "Playing and discussing digital games across all genres, from indie to AAA." },
                new Interest() { Id = 4, Name = "Cooking", Description = "Experimenting with recipes and cuisines from around the world." },
                new Interest() { Id = 5, Name = "Machine Learning", Description = "Studying and applying ML algorithms and neural networks to real-world problems." }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link() { Id = 1, URL = "https://www.flickr.com/people/alicejohnson", UserId = 1, InterestId = 1 },
                new Link() { Id = 2, URL = "https://github.com/alicejohnson-ml", UserId = 1, InterestId = 5 },
                new Link() { Id = 3, URL = "https://www.alltrails.com/members/bobmartinez", UserId = 2, InterestId = 2 },
                new Link() { Id = 4, URL = "https://www.youtube.com/@bobcooks", UserId = 2, InterestId = 4 },
                new Link() { Id = 5, URL = "https://store.steampowered.com/profiles/claranguyen", UserId = 3, InterestId = 3 },
                new Link() { Id = 6, URL = "https://www.instagram.com/clara.shoots", UserId = 3, InterestId = 1 },
                new Link() { Id = 7, URL = "https://www.kaggle.com/davidokonkwo", UserId = 4, InterestId = 5 },
                new Link() { Id = 8, URL = "https://www.strava.com/athletes/davidokonkwo", UserId = 4, InterestId = 2 },
                new Link() { Id = 9, URL = "https://www.foodnetwork.com/profiles/evalindstrom", UserId = 5, InterestId = 4 },
                new Link() { Id = 10, URL = "https://www.twitch.tv/eva_plays", UserId = 5, InterestId = 3 }
            );

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Interests)
                        .WithMany(i => i.Users)
                        .UsingEntity(j => j.HasData(
                new { UsersId = 1, InterestsId = 1 },
                new { UsersId = 1, InterestsId = 5 },
                new { UsersId = 2, InterestsId = 2 },
                new { UsersId = 2, InterestsId = 4 },
                new { UsersId = 3, InterestsId = 3 },
                new { UsersId = 3, InterestsId = 1 },
                new { UsersId = 4, InterestsId = 5 },
                new { UsersId = 4, InterestsId = 2 },
                new { UsersId = 5, InterestsId = 4 },
                new { UsersId = 5, InterestsId = 3 }
           ));

        }
    }
}
