using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class ExtendEmployerToNameDescriptionAndWebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Employers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Employers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "40a5a1f2-0a17-4ffc-a1ce-6cbd5da723ad", new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6711), new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "72e8e9b7-9aa6-41cf-b5a6-3c501602b469", new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6594), new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6596) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "f19d018f-238b-41f3-b281-01cb47e6653b", new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6694), new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6697) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "6a64afe1-c4c2-40ae-bdd1-1bf03a762389", new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6679), new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "770258a9-57be-468d-b02d-2e5c86d69445", new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6660), new DateTime(2023, 5, 10, 23, 2, 12, 508, DateTimeKind.Local).AddTicks(6663) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Employers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "b5818645-b104-434e-885e-ab44ad5bcadc", new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5132), new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5135) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "68cb6fde-24ee-4f03-ba6c-c4a404d8f613", new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(4909), new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "04f60601-bba7-45ef-812c-9c92a2736fd0", new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5100), new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5103) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "b5b762fa-d980-474d-8860-5b918e90f84b", new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5069), new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "99a86bcb-bfcf-4efb-b43d-b10772634446", new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5035), new DateTime(2023, 5, 10, 13, 12, 4, 209, DateTimeKind.Local).AddTicks(5037) });
        }
    }
}
