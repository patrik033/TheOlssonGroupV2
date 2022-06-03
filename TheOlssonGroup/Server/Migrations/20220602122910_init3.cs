using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheOlssonGroup.Server.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f6de07e-ef9f-4283-bb8c-fc215e07835e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c36f1b9d-6659-43b2-969a-b7ba123506ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc6340e-2b94-46af-a1c0-49f1389e26d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "624318bf-b1de-4630-9fdd-350d407495f7", "79406f42-189a-48a7-9f92-0f49d50bbdf6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e84260c-53f5-40a7-9e5d-c28b12e3c8ed", "364809fa-6742-4b84-8578-195b00dd99c4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "04d45b31-cc3d-4c40-b16f-e17b6fa78726", 0, "456c1347-6005-4b66-b7ef-481024e1981a", "IdentityUser", "Admin@Olsson.com", true, false, null, null, null, null, null, false, "d33d790f-af37-4b0d-9692-1ddad3060bb0", false, "Admin@Olsson.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "624318bf-b1de-4630-9fdd-350d407495f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e84260c-53f5-40a7-9e5d-c28b12e3c8ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04d45b31-cc3d-4c40-b16f-e17b6fa78726");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f6de07e-ef9f-4283-bb8c-fc215e07835e", "88330d63-a178-484e-862e-b905ba7bdea6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c36f1b9d-6659-43b2-969a-b7ba123506ae", "0c3e68c0-e2f8-4b9c-ad3f-33396398f9ee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "afc6340e-2b94-46af-a1c0-49f1389e26d5", 0, "47d19855-3e58-4649-8cd7-be0cda372814", "IdentityUser", "Admin@Olsson.com", true, false, null, null, null, null, null, false, "96aa7cac-151e-4108-8949-75d0c0a07668", false, "Admin@Olsson.com" });
        }
    }
}
