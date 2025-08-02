using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class User_Identity_dataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "41776062-6086-1fbf-b923-2879a6680b9a", 0, "b18345a3-7465-403d-b89f-f9a03bf81a0a", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEBaHHVx//0zdZyHf96DfbYbqWwysEGmzdwak4G5lqJPlU3W70LtmIdNz51/Eq4Z6Xg==", null, false, "206f9b66-7b57-47c5-8cdb-7aaecccf7b7a", false, "admin@gmail.com" },
                    { "41776062-6086-1fbf-b923-2879a6680b9b", 0, "cdaf25f1-f9f6-41ba-8a50-2d4b1496b727", "mandhare@gmail.com", false, false, null, "MANDHARE@GMAIL.COM", "MANDHARE@GMAIL.COM", "AQAAAAIAAYagAAAAEKMpb3qzwgLHdjyCCaGdtQzudatX4xswjyuEBi88aUnEmih12lfut2zH9Afx0EhQMg==", null, false, "3fb771a2-2d10-4e39-9397-780d0d9612d6", false, "mandhare@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9b");
        }
    }
}
