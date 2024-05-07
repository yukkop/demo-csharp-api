using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class SuperUserCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("9d95bebb-7bc4-4316-a88f-298eea345536"), 0, "c4263fbc-ba09-46d3-a158-cad594ac3e3b", new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "yukkop@admin.dev", true, false, null, "YUKKOP@ADMIN.DEV", "admin", "YWRtaW4=", "", false, "MRPQE6W55J6KIZMCPQCRVL7CC6HT66BQ", false, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d95bebb-7bc4-4316-a88f-298eea345536"));
        }
    }
}
