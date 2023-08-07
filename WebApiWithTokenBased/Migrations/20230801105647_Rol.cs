using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class Rol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fe86809-7d93-474c-a4aa-5dbbef7e620a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d5c2b3-7e9a-417e-ad9c-de0896893907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a544ca93-6d61-4332-88df-8c759bd2ab60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b542d518-c65d-4eff-88f2-50544968773b");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Description", "Discriminator", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09dd8db6-045d-4ae1-882a-9f8b28b503cb", "14ec3c91-f92d-4eff-aa15-eb2adca108e0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Editor", "EDITOR" },
                    { "2926f8b5-9a92-4e44-b5ca-c3e2ffdc0d35", "cb0c43a7-d8c3-4ba8-a7a2-bbc782881838", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Admin", "ADMIN" },
                    { "7270b32d-34d4-4168-9420-e9435bd26b3e", "b99910a9-aee8-4584-89a3-c3fb2d200683", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "User", "USER" },
                    { "dee902e1-20e7-4baa-84a7-3622119c77b8", "ac9d30d6-a471-4e58-82d4-eba6e1cf888d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Moderator", "MODERATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09dd8db6-045d-4ae1-882a-9f8b28b503cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2926f8b5-9a92-4e44-b5ca-c3e2ffdc0d35");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7270b32d-34d4-4168-9420-e9435bd26b3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dee902e1-20e7-4baa-84a7-3622119c77b8");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Description", "Discriminator", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fe86809-7d93-474c-a4aa-5dbbef7e620a", "4a6e6908-6e0e-43c3-9880-d56824bec7ed", new DateTime(2023, 7, 31, 10, 41, 2, 999, DateTimeKind.Local).AddTicks(8716), "System", "Default Description", "UserRole", false, "Admin", "ADMIN" },
                    { "31d5c2b3-7e9a-417e-ad9c-de0896893907", "f4fc686c-d83d-49eb-8813-952a1ba32ec9", new DateTime(2023, 7, 31, 10, 41, 2, 999, DateTimeKind.Local).AddTicks(8671), "System", "Default Description", "UserRole", false, "Editor", "EDITOR" },
                    { "a544ca93-6d61-4332-88df-8c759bd2ab60", "dedb9ed7-12a0-4eee-a555-9f2726458592", new DateTime(2023, 7, 31, 10, 41, 2, 999, DateTimeKind.Local).AddTicks(8653), "System", "Default Description", "UserRole", false, "User", "USER" },
                    { "b542d518-c65d-4eff-88f2-50544968773b", "5fff8891-f1f9-4833-9f00-9174d6cabaf8", new DateTime(2023, 7, 31, 10, 41, 2, 999, DateTimeKind.Local).AddTicks(8710), "System", "Default Description", "UserRole", false, "Moderator", "MODERATOR" }
                });
        }
    }
}
