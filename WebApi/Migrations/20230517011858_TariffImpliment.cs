using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class TariffImpliment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeriodUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MaxUserCount = table.Column<int>(type: "integer", nullable: false),
                    MinUserCount = table.Column<int>(type: "integer", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    PeriodUnitId = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("28d75a01-942f-446d-9986-6321141914e1")),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tariffs_PeriodUnits_PeriodUnitId",
                        column: x => x.PeriodUnitId,
                        principalTable: "PeriodUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "5b09c1c8-cd23-4b49-abc0-dce842be981e", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(747), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(750) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "7582171f-aba6-494a-8041-b7fd73400606", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(587), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "ca850c90-bc83-4bf8-a90d-ab20e8becec2", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(723), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(727) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "f1470b22-c0b0-4bca-9205-e2b002fd3538", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(698), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "3fd0e858-7863-4c69-a6fb-46d31ea35394", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(670), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(674) });

            migrationBuilder.InsertData(
                table: "PeriodUnits",
                columns: new[] { "Id", "CreatedAt", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("15266afb-5997-43ee-93a5-15e6a5b394bf"), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(867), "year", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(871) },
                    { new Guid("28d75a01-942f-446d-9986-6321141914e1"), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(828), "day", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(832) },
                    { new Guid("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(849), "month", new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(853) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccesses_BundleId",
                table: "EmployeeAccesses",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tariffs_PeriodUnitId",
                table: "Tariffs",
                column: "PeriodUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAccesses_Bundles_BundleId",
                table: "EmployeeAccesses",
                column: "BundleId",
                principalTable: "Bundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAccesses_Bundles_BundleId",
                table: "EmployeeAccesses");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "PeriodUnits");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAccesses_BundleId",
                table: "EmployeeAccesses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "d7dad417-1237-4fa3-ad9f-1731a0872c0b", new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7781), new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7783) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "9851a98f-f6e4-41f4-979c-17c85d7074ff", new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7617), new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7619) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "324382bd-324c-4fe6-960f-bb459ec37dcf", new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7766), new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7768) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "e8ab7c7e-7b2b-44d7-8bc1-2c4a9166046e", new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7752), new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7754) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "f4bb1ec2-0f52-4a22-b2f1-5092eb8e5f34", new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7735), new DateTime(2023, 5, 12, 5, 38, 2, 299, DateTimeKind.Local).AddTicks(7737) });
        }
    }
}
