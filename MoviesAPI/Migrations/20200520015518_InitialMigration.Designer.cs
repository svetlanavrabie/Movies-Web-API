﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAPI.Contexts;

namespace MoviesAPI.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20200520015518_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesAPI.Entities.Director", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            FirstName = "Martin",
                            LastName = "Scorsese"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            FirstName = "Anthony",
                            LastName = "Russo"
                        },
                        new
                        {
                            Id = new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                            FirstName = "James",
                            LastName = "Gray"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            FirstName = "Jake",
                            LastName = "Kasdan"
                        });
                });

            modelBuilder.Entity("MoviesAPI.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(2500)")
                        .HasMaxLength(2500);

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(2500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            Category = "Comedy/Action",
                            Description = "When Spencer goes back into the fantastical world of Jumanji, pals Martha, Fridge and Bethany re-enter the game to bring him home. But the game is now broken -- and fighting back.",
                            DirectorId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            ReleaseDate = new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Jumanji: The Next Level"
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                            Category = "Crime/Drama",
                            Description = "In the 1950s, truck driver Frank Sheeran gets involved with Russell Bufalino and his Pennsylvania crime family. As Sheeran climbs the ranks to become a top hit man, he also goes to work for Jimmy Hoffa -- a powerful Teamster tied to organized crime.",
                            DirectorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ReleaseDate = new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Irishman"
                        },
                        new
                        {
                            Id = new Guid("493c3228-3444-4a49-9cc0-e8532edc59b2"),
                            Category = "Drama/Epic",
                            Description = "Howard Hughes, who suffers from germophobia and psychological illness, tries to design and promote a new aircraft. Along the way, he faces personal issues but becomes a successful film-maker.",
                            DirectorId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            ReleaseDate = new DateTime(2004, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Aviator"
                        },
                        new
                        {
                            Id = new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                            Category = "Action/Sci-fi",
                            Description = "After Thanos, an intergalactic warlord, disintegrates half of the universe, the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.",
                            DirectorId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            ReleaseDate = new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers: Endgame"
                        },
                        new
                        {
                            Id = new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                            Category = "Crime/Drama",
                            Description = "Bobby Green, the manager of a nightclub, keeps himself away from trouble despite the frequent visits by many gangsters. However, things take a turn when his brother is attacked by the Russian mafia.",
                            DirectorId = new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                            ReleaseDate = new DateTime(2007, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "We Own the Night"
                        });
                });

            modelBuilder.Entity("MoviesAPI.Entities.Movie", b =>
                {
                    b.HasOne("MoviesAPI.Entities.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
