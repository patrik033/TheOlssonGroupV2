using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheOlssonGroup.Server.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ebf560d-dec7-4e1f-acae-ab1a0d2148b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97858122-519a-40d6-845e-d5191267dce4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bd3e76d-6eb5-4dde-94b4-4bbd2e799614");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3ebf560d-dec7-4e1f-acae-ab1a0d2148b7", "e3785046-c145-49ec-9078-e956d552d582", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97858122-519a-40d6-845e-d5191267dce4", "130f2899-f256-4fbd-a8f5-038149b444cf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7bd3e76d-6eb5-4dde-94b4-4bbd2e799614", 0, "e3014df7-eb94-4c03-a90d-ee85538c6d1e", "IdentityUser", "Admin@Olsson.com", true, false, null, null, null, null, null, false, "6649ab43-fa15-49c7-b8a6-f83b5197a7a7", false, "Admin@Olsson.com" });
        }
    }
}
