using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web_API.Migrations
{
    /// <inheritdoc />
    public partial class seeduserinterests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InterestUser",
                columns: new[] { "InterestsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 3 },
                    { 3, 5 },
                    { 4, 2 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "InterestUser",
                keyColumns: new[] { "InterestsId", "UsersId" },
                keyValues: new object[] { 5, 4 });
        }
    }
}
