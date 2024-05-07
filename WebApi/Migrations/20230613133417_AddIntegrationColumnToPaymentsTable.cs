using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddIntegrationColumnToPaymentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Integration",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "71aee161-0db1-4999-9422-60aeb586251a", new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7153), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "c1c3c108-14af-4c1c-86fe-2d01d6e062ad", new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(6930), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(6944) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "714ade51-f0e7-4a39-bae4-3653581dde72", new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7115), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "1808e335-ea7f-45d8-b67b-04db3182ea65", new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7072), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7087) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "44fc9b8e-e6c6-40e6-a865-275eec2db1fa", new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7034), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7048) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("15266afb-5997-43ee-93a5-15e6a5b394bf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7293), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7302) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("28d75a01-942f-446d-9986-6321141914e1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7231), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7264), new DateTime(2023, 6, 13, 15, 34, 17, 248, DateTimeKind.Local).AddTicks(7279) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Integration",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "10bb1c66-37e8-4e09-9fe6-72a07cbbc70b", new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8991), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8998) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "ec8cf937-2042-4be9-8cfa-17e7f4beb022", new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8851), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8854) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "3d6df8cd-4f76-4397-94ab-1d277808b270", new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8973), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8976) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "7a818956-dde7-445f-afd8-83f10fcdf6e9", new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8954), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "433f606c-703c-4556-b9b7-d0a029c06c5b", new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8934), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(8937) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("15266afb-5997-43ee-93a5-15e6a5b394bf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9107), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("28d75a01-942f-446d-9986-6321141914e1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9068), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9073) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9089), new DateTime(2023, 6, 12, 0, 20, 24, 940, DateTimeKind.Local).AddTicks(9092) });
        }
    }
}
