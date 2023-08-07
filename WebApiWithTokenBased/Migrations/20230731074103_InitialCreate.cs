using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e1198b0-aa6b-423f-8a00-641ba576196e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b9d164c-3038-4cb2-8d8c-265738b8ee97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ab546f-f2b6-4fbb-af7b-b72447d52e9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18131c1-b0ee-429d-8e18-b2e6ed83dcbe");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e1198b0-aa6b-423f-8a00-641ba576196e", "18d30f19-2448-45f0-acce-d07f555aa6fb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "Editor", "EDITOR" },
                    { "4b9d164c-3038-4cb2-8d8c-265738b8ee97", "9cbc6e93-0cba-464c-9baf-55f29b89cc94", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "User", "USER" },
                    { "87ab546f-f2b6-4fbb-af7b-b72447d52e9a", "5dc1db03-7ef5-4bda-bc3a-93d34059bb00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "Admin", "ADMIN" },
                    { "f18131c1-b0ee-429d-8e18-b2e6ed83dcbe", "0bdf35f6-cf80-4545-aef7-86ba550d15ab", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "Moderator", "MODERATOR" }
                });
        }
    }
}
