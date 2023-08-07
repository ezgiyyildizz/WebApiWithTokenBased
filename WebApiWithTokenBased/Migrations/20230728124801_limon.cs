using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class limon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "500b5d76-87a0-4b2b-b6ef-52efb1645540");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12c134d-6f3d-4b3e-8bc0-73518674786d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0b1e6ef-da45-42fd-87e3-ec2a24b362d1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "500b5d76-87a0-4b2b-b6ef-52efb1645540", "dd598fcf-7277-4978-addf-e92d5d1ff338", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "c12c134d-6f3d-4b3e-8bc0-73518674786d", "04b99c91-e6af-45b9-8144-81669903b976", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "e0b1e6ef-da45-42fd-87e3-ec2a24b362d1", "bade2dc0-6ed1-47d4-bd02-6ebd508c56d5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserRole", "User", "USER" });
        }
    }
}
