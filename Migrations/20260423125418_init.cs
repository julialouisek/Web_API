using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Capturing moments through a camera lens, from landscape to portrait photography.", "Photography" },
                    { 2, "Exploring nature trails and mountains on foot, enjoying the outdoors.", "Hiking" },
                    { 3, "Playing and discussing digital games across all genres, from indie to AAA.", "Video Games" },
                    { 4, "Experimenting with recipes and cuisines from around the world.", "Cooking" },
                    { 5, "Studying and applying ML algorithms and neural networks to real-world problems.", "Machine Learning" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Alice Johnson", "+1-555-0101" },
                    { 2, "Bob Martinez", "+1-555-0202" },
                    { 3, "Clara Nguyen", "+44-7700-900303" },
                    { 4, "David Okonkwo", "+46-70-440-0404" },
                    { 5, "Eva Lindström", "+46-73-550-0505" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "URL", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "https://www.flickr.com/people/alicejohnson", 1 },
                    { 2, 5, "https://github.com/alicejohnson-ml", 1 },
                    { 3, 2, "https://www.alltrails.com/members/bobmartinez", 2 },
                    { 4, 4, "https://www.youtube.com/@bobcooks", 2 },
                    { 5, 3, "https://store.steampowered.com/profiles/claranguyen", 3 },
                    { 6, 1, "https://www.instagram.com/clara.shoots", 3 },
                    { 7, 5, "https://www.kaggle.com/davidokonkwo", 4 },
                    { 8, 2, "https://www.strava.com/athletes/davidokonkwo", 4 },
                    { 9, 4, "https://www.foodnetwork.com/profiles/evalindstrom", 5 },
                    { 10, 3, "https://www.twitch.tv/eva_plays", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserId",
                table: "Links",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
