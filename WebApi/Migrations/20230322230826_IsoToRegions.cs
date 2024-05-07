using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class IsoToRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Port",
                table: "Servers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsoCountryCode",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CertificateId",
                table: "AspNetUsers",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Certificates_CertificateId",
                table: "AspNetUsers",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Certificates_CertificateId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CertificateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IsoCountryCode",
                table: "Regions");
        }
    }
}
