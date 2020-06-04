using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;

namespace MoviesAPI.Contexts
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Director>().HasData(
                new Director()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Martin",
                    LastName = "Scorsese"
                },

                new Director()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Anthony",
                    LastName = "Russo"
                },

                 new Director()
                 {
                     Id = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                     FirstName = "James",
                     LastName = "Gray"
                 },

                   new Director()
                   {
                       Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                       FirstName = "Jake",
                       LastName = "Kasdan"
                   }
                );

            // seed the database with dummy data
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    DirectorId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Title = "Jumanji: The Next Level",
                    Category = "Comedy/Action",
                    Description = "When Spencer goes back into the fantastical world of Jumanji, pals Martha, Fridge and Bethany re-enter the game to bring him home. But the game is now broken -- and fighting back.",
                    ReleaseDate = new DateTime(2019, 12, 4)
                },

                 new Movie()
                 {
                     Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                     DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                     Title = "The Irishman",
                     Category = "Crime/Drama",
                     Description = "In the 1950s, truck driver Frank Sheeran gets involved with Russell Bufalino and his Pennsylvania crime family. As Sheeran climbs the ranks to become a top hit man, he also goes to work for Jimmy Hoffa -- a powerful Teamster tied to organized crime.",
                     ReleaseDate = new DateTime(2019, 9, 27)
                 },

                  new Movie()
                  {
                      Id = Guid.Parse("493c3228-3444-4a49-9cc0-e8532edc59b2"),
                      DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                      Title = "The Aviator",
                      Category = "Drama/Epic",
                      Description = "Howard Hughes, who suffers from germophobia and psychological illness, tries to design and promote a new aircraft. Along the way, he faces personal issues but becomes a successful film-maker.",
                      ReleaseDate = new DateTime(2004, 12, 25)
                  },

                   new Movie()
                   {
                       Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                       DirectorId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                       Title = "Avengers: Endgame",
                       Category = "Action/Sci-fi",
                       Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.",
                       ReleaseDate = new DateTime(2019, 4, 26)
                   },

                   new Movie()
                   {
                       Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                       DirectorId = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                       Title = "We Own the Night",
                       Category = "Crime/Drama",
                       Description = "Bobby Green, the manager of a nightclub, keeps himself away from trouble despite the frequent visits by many gangsters. However, things take a turn when his brother is attacked by the Russian mafia.",
                       ReleaseDate = new DateTime(2007, 5, 25)
                   }
                 );

            base.OnModelCreating(modelBuilder);
        }
    }
}
