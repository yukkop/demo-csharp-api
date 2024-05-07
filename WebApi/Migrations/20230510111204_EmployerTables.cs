using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class EmployerTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "VpnUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BundleId = table.Column<Guid>(type: "uuid", nullable: false),
                    VpnUserId = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxEmployees = table.Column<int>(type: "integer", nullable: false),
                    LastBalanceDecreaseAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundles_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_VpnUsers_UserId",
                table: "VpnUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bundles_EmployerId",
                table: "Bundles",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VpnUserId",
                table: "Employees",
                column: "VpnUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserId",
                table: "Employers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_PaymentId",
                table: "UserPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_UserId",
                table: "UserPayments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VpnUsers_AspNetUsers_UserId",
                table: "VpnUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VpnUsers_AspNetUsers_UserId",
                table: "VpnUsers");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserPayments");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_VpnUsers_UserId",
                table: "VpnUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VpnUsers");

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
        }
    }
}
