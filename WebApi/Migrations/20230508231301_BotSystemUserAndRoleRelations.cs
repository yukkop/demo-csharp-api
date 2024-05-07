using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class BotSystemUserAndRoleRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "1f2eba0a-7947-4eec-bffd-2ee0d8c3ce70", new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8986), new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "3fd7367c-5fda-4ee8-8817-5f7b5f7fa1f4", new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8568), new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8572) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "e58f9ee2-5da6-4b23-9f35-a9ecad4cd069", new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8947), new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8950) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "a20d5663-bb3c-49c3-abdb-dcfad428bc22", new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8908), new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "4102391e-28e3-4607-9d55-7ed7b4f277f6", new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8861), new DateTime(2023, 5, 9, 1, 13, 1, 37, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"), new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9") });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3"), 0, "05499e8c-2786-48a2-bfd4-3826b69c2f7e", new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "bot-system", false, false, null, "BOT-SYSTEM", "BOT-SYSTEM", "AQAAAAEAACcQAAAAEI8giejNCgpSybLTuF2pxOtF6ProHJSdaJ+4IBrxuWr5w9tNVOfvKaLUAzvozSzt1Q==", "", false, "MA6F44AWYGATEQBSENVLAETCPZ2ATT2N", false, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "bot-system" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9e479955-2de9-4a9d-b922-bbea18871593"), new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9e479955-2de9-4a9d-b922-bbea18871593"), new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"), new Guid("ad15c6e6-9ee1-45ce-b302-7d97c05981a9") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f543b93-c9e8-4cb4-9b97-50c853be65f3"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "707d5a8d-a5cc-4644-93a1-12e5ce1bb229", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7412), new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "55d6bf9b-16bc-4117-8f3f-6b3210d2d0b4", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7074), new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7077) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eea7e623-4b91-48ed-b2ce-0b735658e7a6", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7375), new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7378) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "23e53817-0a9a-4d6c-a413-5b122a2b4e43", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7339), new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "4aee683f-2929-4a9a-aa07-b806a84e9563", new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7300), new DateTime(2023, 5, 8, 5, 2, 27, 17, DateTimeKind.Local).AddTicks(7303) });
        }
    }
}
