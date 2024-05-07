using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddNewRolesAndFixSuperUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("084cb6f3-8fd9-4d4f-8628-1317ce96a568"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36d8f10c-a174-4d89-884e-e43c0b1adb8e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a70d7bfe-afa2-4c57-a89a-a126bcd5ec93"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d95bebb-7bc4-4316-a88f-298eea345536"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"), "707d5a8d-a5cc-4644-93a1-12e5ce1bb229", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7412), "Employer", "EMPLOYER", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7415) },
                    { new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"), "55d6bf9b-16bc-4117-8f3f-6b3210d2d0b4", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7074), "Super", "SUPER", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7077) },
                    { new Guid("9e479955-2de9-4a9d-b922-bbea18871593"), "eea7e623-4b91-48ed-b2ce-0b735658e7a6", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7375), "BotSystem", "BOTSYSTEM", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7378) },
                    { new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"), "23e53817-0a9a-4d6c-a413-5b122a2b4e43", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7339), "VpnUser", "VPNUSER", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7342) },
                    { new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"), "4aee683f-2929-4a9a-aa07-b806a84e9563", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7300), "Admin", "ADMIN", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7303) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"), 0, "8c564238-a0f0-431e-94e5-a27e0a1e5930", new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "super", false, false, null, "SUPER", "SUPER", "AQAAAAEAACcQAAAAELhbCt2KM3WtIHFvL1tgqRYuUSf1N43Iu4jpNMIvZLFqXS2W/IO2f2cGaGHLaUFScQ==", "", false, "VKAM7OMLKEQLLLGFQUSC64WVQFY3RURV", false, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "super" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("084cb6f3-8fd9-4d4f-8628-1317ce96a568"), "4c862faa-ff10-4d67-afb0-d65cc29d3554", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2186), "Admin", "ADMIN", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2190) },
                    { new Guid("36d8f10c-a174-4d89-884e-e43c0b1adb8e"), "d639e5c0-f67c-4ba0-b2e9-872c943322cc", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2229), "VpnUser", "VPNUSER", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2232) },
                    { new Guid("a70d7bfe-afa2-4c57-a89a-a126bcd5ec93"), "4cf191f5-3135-4478-bf08-95f5e4f8470d", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1948), "Super", "SUPER", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1953) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("9d95bebb-7bc4-4316-a88f-298eea345536"), 0, "c4263fbc-ba09-46d3-a158-cad594ac3e3b", new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "yukkop@admin.dev", true, false, null, "YUKKOP@ADMIN.DEV", "admin", "YWRtaW4=", "", false, "MRPQE6W55J6KIZMCPQCRVL7CC6HT66BQ", false, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }
    }
}
