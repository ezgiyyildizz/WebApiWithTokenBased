using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class Token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2074461d-f060-4fd2-9077-b81d5a7e337a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93449e23-e8a1-41f7-868e-66179fae6c76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc5890e6-1287-4c15-8de6-9324fa12c889");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2074461d-f060-4fd2-9077-b81d5a7e337a", "b5cc4999-9694-4f38-b46a-13bb94c2f260", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93449e23-e8a1-41f7-868e-66179fae6c76", "e72aa768-37c7-402b-8a05-672d3b08f705", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc5890e6-1287-4c15-8de6-9324fa12c889", "011b4257-5284-42e4-9b26-ab02c9b7ccbf", "User", "USER" });
        }
    }
}
