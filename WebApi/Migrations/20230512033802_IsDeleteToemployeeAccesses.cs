using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class IsDeleteToemployeeAccesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.CreateTable(
                name: "EmployeeAccesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BundleId = table.Column<Guid>(type: "uuid", nullable: false),
                    VpnUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Code = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAccesses_VpnUsers_VpnUserId",
                        column: x => x.VpnUserId,
                        principalTable: "VpnUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccesses_VpnUserId",
                table: "EmployeeAccesses",
                column: "VpnUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAccesses");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VpnUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BundleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_VpnUsers_VpnUserId",
                        column: x => x.VpnUserId,
                        principalTable: "VpnUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VpnUserId",
                table: "Employees",
                column: "VpnUserId");
        }
    }
}
