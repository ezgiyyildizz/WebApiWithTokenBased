using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class EFCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8c37351-b190-4b7a-bf14-ce22e880c89d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db5b226f-c529-4428-9a3b-0b0505258d17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14aa1ff-cf31-4a86-b870-8c18f6b91361");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b8c37351-b190-4b7a-bf14-ce22e880c89d", "32211717-607f-43cf-9b66-9ef2eb7e898c", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db5b226f-c529-4428-9a3b-0b0505258d17", "57814957-f46c-4395-a529-09e9d781edc0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e14aa1ff-cf31-4a86-b870-8c18f6b91361", "70cb974e-a73a-4001-803c-40557677eb7a", "Admin", "ADMIN" });
        }
    }
}
