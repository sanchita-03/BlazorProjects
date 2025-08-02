using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class Role_UserRole_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", null, "Admin", "ADMIN" },
                    { "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3bc464e-cab8-4061-897f-18ca341cb1a6", "AQAAAAIAAYagAAAAEG0GuKPPNG/uTRjUejIIwnq8+CELIz+rY6iPfV13FeSQ6qgBhsUQlniY4LYbS+vHfQ==", "3471825b-4377-4c1e-bd43-396d14f8f231" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74d88241-19cb-4649-a59a-49d60e0a5f6e", "AQAAAAIAAYagAAAAEG1truGDtbRYw7LZb9kBu94PPc67dy8gUhljjmW5tCPuD7zfWOORWjInIoQJ/x05ug==", "9dc28f45-bd5e-4c8b-8fee-7ec4f63e7693" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", "41776062-6086-1fbf-b923-2879a6680b9a" },
                    { "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e", "41776062-6086-1fbf-b923-2879a6680b9b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d", "41776062-6086-1fbf-b923-2879a6680b9a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e", "41776062-6086-1fbf-b923-2879a6680b9b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a3-c435-4ee7-8c75-bbf66fc8f38d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab04a4-c435-4ee7-8c75-bbf66cd8f38e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b18345a3-7465-403d-b89f-f9a03bf81a0a", "AQAAAAIAAYagAAAAEBaHHVx//0zdZyHf96DfbYbqWwysEGmzdwak4G5lqJPlU3W70LtmIdNz51/Eq4Z6Xg==", "206f9b66-7b57-47c5-8cdb-7aaecccf7b7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062-6086-1fbf-b923-2879a6680b9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdaf25f1-f9f6-41ba-8a50-2d4b1496b727", "AQAAAAIAAYagAAAAEKMpb3qzwgLHdjyCCaGdtQzudatX4xswjyuEBi88aUnEmih12lfut2zH9Afx0EhQMg==", "3fb771a2-2d10-4e39-9397-780d0d9612d6" });
        }
    }
}
