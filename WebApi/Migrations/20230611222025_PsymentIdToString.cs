using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class PsymentIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentId",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                table: "Payments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
        }
    }
}
