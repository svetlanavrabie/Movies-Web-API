using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", maxLength: 2500, nullable: false),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Martin", "Scorsese" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Anthony", "Russo" },
                    { new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"), "James", "Gray" },
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Jake", "Kasdan" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Category", "Description", "DirectorId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "Crime/Drama", "In the 1950s, truck driver Frank Sheeran gets involved with Russell Bufalino and his Pennsylvania crime family. As Sheeran climbs the ranks to become a top hit man, he also goes to work for Jimmy Hoffa -- a powerful Teamster tied to organized crime.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(2019, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Irishman" },
                    { new Guid("493c3228-3444-4a49-9cc0-e8532edc59b2"), "Drama/Epic", "Howard Hughes, who suffers from germophobia and psychological illness, tries to design and promote a new aircraft. Along the way, he faces personal issues but becomes a successful film-maker.", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(2004, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Aviator" },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), "Action/Sci-fi", "After Thanos, an intergalactic warlord, disintegrates half of the universe, the Avengers must reunite and assemble again to reinvigorate their trounced allies and restore balance.", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers: Endgame" },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), "Crime/Drama", "Bobby Green, the manager of a nightclub, keeps himself away from trouble despite the frequent visits by many gangsters. However, things take a turn when his brother is attacked by the Russian mafia.", new Guid("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"), new DateTime(2007, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "We Own the Night" },
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "Comedy/Action", "When Spencer goes back into the fantastical world of Jumanji, pals Martha, Fridge and Bethany re-enter the game to bring him home. But the game is now broken -- and fighting back.", new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), new DateTime(2019, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jumanji: The Next Level" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
