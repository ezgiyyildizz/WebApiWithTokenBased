using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class son : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Description", "Discriminator", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1d77e8f-e981-4bfb-a290-ac33437c2dad", "45475618-42bc-46cb-8786-88bffff573ec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Moderator", "MODERATOR" },
                    { "ac5a992e-b6e7-4a01-89e7-b7107802984b", "48a3c16f-4528-42c8-b1c8-a437aba413f1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Admin", "ADMIN" },
                    { "b1169c43-689e-4979-a11a-117204ae38c6", "92a06b74-b9fb-4867-87e2-98c0539043db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "User", "USER" },
                    { "d0c9fdec-22f4-49c0-bdf6-389845fbeb1a", "f6685463-d062-41ce-bb13-09a41d0bacb6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1d77e8f-e981-4bfb-a290-ac33437c2dad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac5a992e-b6e7-4a01-89e7-b7107802984b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1169c43-689e-4979-a11a-117204ae38c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0c9fdec-22f4-49c0-bdf6-389845fbeb1a");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
