using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class VpnUsersAndPaymentIntersectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VpnUsersPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    VpnUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpnUsersPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VpnUsersPayments_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VpnUsersPayments_VpnUsers_VpnUserId",
                        column: x => x.VpnUserId,
                        principalTable: "VpnUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VpnUsersPayments_PaymentId",
                table: "VpnUsersPayments",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_VpnUsersPayments_VpnUserId",
                table: "VpnUsersPayments",
                column: "VpnUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VpnUsersPayments");
        }
    }
}
