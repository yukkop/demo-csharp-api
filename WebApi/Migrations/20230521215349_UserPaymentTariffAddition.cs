using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class UserPaymentTariffAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TariffId",
                table: "UserPayments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d939b37-0430-49b3-a3ab-ae83913e3745"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "8784584c-a6dc-4727-a669-dcdc1002b5c3", new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5645), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2f0bd97b-dd0d-4f54-9a4c-f89cdc06c52d"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "4cb6910c-97ea-43c2-bb5b-a721d7ccb9c3", new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5544), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e479955-2de9-4a9d-b922-bbea18871593"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "bb1c1ddd-f495-4eec-98ff-9b4d04471ec3", new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5631), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f176c034-6c6c-4f7f-8841-2bd5b05a702a"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "6d1ed60c-a053-49aa-a6d1-8457509c1d5e", new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5615), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5618) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fac6a18c-14b6-4427-981b-7bbaaa77b7c6"),
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "UpdatedAt" },
                values: new object[] { "de3b55cc-4873-4825-acf0-55af96af8755", new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5599), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5602) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("15266afb-5997-43ee-93a5-15e6a5b394bf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5717), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("28d75a01-942f-446d-9986-6321141914e1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5693), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5695) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5706), new DateTime(2023, 5, 21, 23, 53, 48, 843, DateTimeKind.Local).AddTicks(5709) });

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_TariffId",
                table: "UserPayments",
                column: "TariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPayments_Tariffs_TariffId",
                table: "UserPayments",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPayments_Tariffs_TariffId",
                table: "UserPayments");

            migrationBuilder.DropIndex(
                name: "IX_UserPayments_TariffId",
                table: "UserPayments");

            migrationBuilder.DropColumn(
                name: "TariffId",
                table: "UserPayments");

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

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("15266afb-5997-43ee-93a5-15e6a5b394bf"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(867), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(871) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("28d75a01-942f-446d-9986-6321141914e1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(828), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(832) });

            migrationBuilder.UpdateData(
                table: "PeriodUnits",
                keyColumn: "Id",
                keyValue: new Guid("9ebbb82c-27ef-4a25-a93e-524d61b0a4d7"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(849), new DateTime(2023, 5, 17, 3, 18, 57, 375, DateTimeKind.Local).AddTicks(853) });
        }
    }
}
