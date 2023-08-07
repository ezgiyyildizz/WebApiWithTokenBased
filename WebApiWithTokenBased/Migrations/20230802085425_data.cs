using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithTokenBased.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "CreatedBy", "Description", "Discriminator", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4eb0466f-a1ab-4d47-b7fc-d9c77eb65a6c", "42fe494e-2925-4891-9de7-492b32113174", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "User", "USER" },
                    { "b549b8da-0505-4a02-94b6-18c02a536df0", "f19ab38d-b3f8-499b-967b-d196503e2bb4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Moderator", "MODERATOR" },
                    { "b5a08b6d-e81f-44da-9db2-248f2c39c044", "3140f6ab-6c82-47d1-9d73-3fa1ee04327c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Admin", "ADMIN" },
                    { "d570fdba-78f0-471b-a528-6c2081a00528", "f91ef30c-eccc-4e4e-a4ad-af676a43245c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Default Description", "UserRole", false, "Editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb0466f-a1ab-4d47-b7fc-d9c77eb65a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b549b8da-0505-4a02-94b6-18c02a536df0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5a08b6d-e81f-44da-9db2-248f2c39c044");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d570fdba-78f0-471b-a528-6c2081a00528");

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
    }
}
