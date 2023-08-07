using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class Tokenb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e46eab8-c376-4aa7-91ba-cddd2f98d91d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84b35a6c-5924-49bd-9a68-d672fc057f9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ddd47b-2f36-414b-a61b-e7f524fc9596");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3606fdb9-d13b-4cd1-9790-ed7132dc2a4d", "1ba7d18d-4319-4354-99c4-9aefae37426c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39b2c5e7-e559-4b49-91dd-4575d120a209", "463fe562-bb47-49ae-9bc8-972776eb8e71", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d3b2020-45c4-4cec-9657-faab70da3702", "80834999-3e54-437e-9197-67a7f5ede0bc", "Editor", "EDITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3606fdb9-d13b-4cd1-9790-ed7132dc2a4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39b2c5e7-e559-4b49-91dd-4575d120a209");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d3b2020-45c4-4cec-9657-faab70da3702");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e46eab8-c376-4aa7-91ba-cddd2f98d91d", "541ae383-8b9c-4e2c-a484-927c934bf03a", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84b35a6c-5924-49bd-9a68-d672fc057f9b", "71728c85-a954-4c82-abd9-d06e3e9da167", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0ddd47b-2f36-414b-a61b-e7f524fc9596", "93d1618d-bfdc-40d2-9504-fb0003747673", "Admin", "ADMIN" });
        }
    }
}
