using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class CertificateHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveBytes",
                table: "VpnUsers");

            migrationBuilder.DropColumn(
                name: "TransmitBytes",
                table: "VpnUsers");

            migrationBuilder.AddColumn<decimal>(
                name: "ReceiveBytes",
                table: "Certificates",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransmitBytes",
                table: "Certificates",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "VpnUsersCertificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CertificateId = table.Column<Guid>(type: "uuid", nullable: true),
                    VpnUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VpnUsersCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VpnUsersCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VpnUsersCertificates_VpnUsers_VpnUserId",
                        column: x => x.VpnUserId,
                        principalTable: "VpnUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VpnUsersCertificates_CertificateId",
                table: "VpnUsersCertificates",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_VpnUsersCertificates_VpnUserId",
                table: "VpnUsersCertificates",
                column: "VpnUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VpnUsersCertificates");

            migrationBuilder.DropColumn(
                name: "ReceiveBytes",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "TransmitBytes",
                table: "Certificates");

            migrationBuilder.AddColumn<decimal>(
                name: "ReceiveBytes",
                table: "VpnUsers",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransmitBytes",
                table: "VpnUsers",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
