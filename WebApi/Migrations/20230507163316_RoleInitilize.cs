using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RoleInitilize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("084cb6f3-8fd9-4d4f-8628-1317ce96a568"), "4c862faa-ff10-4d67-afb0-d65cc29d3554", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2186), "Admin", "ADMIN", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2190) },
                    { new Guid("36d8f10c-a174-4d89-884e-e43c0b1adb8e"), "d639e5c0-f67c-4ba0-b2e9-872c943322cc", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2229), "VpnUser", "VPNUSER", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(2232) },
                    { new Guid("a70d7bfe-afa2-4c57-a89a-a126bcd5ec93"), "4cf191f5-3135-4478-bf08-95f5e4f8470d", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1948), "Super", "SUPER", new DateTime(2023, 5, 7, 18, 33, 16, 303, DateTimeKind.Local).AddTicks(1953) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
