using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoonBuck.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class extendidentityuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 24, 9, 58, 47, 932, DateTimeKind.Local).AddTicks(825), new DateTime(2023, 10, 24, 0, 22, 47, 932, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 58, 47, 932, DateTimeKind.Local).AddTicks(830), new DateTime(2023, 10, 25, 0, 22, 47, 932, DateTimeKind.Local).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 58, 47, 932, DateTimeKind.Local).AddTicks(833), new DateTime(2023, 10, 25, 0, 22, 47, 932, DateTimeKind.Local).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 26, 9, 58, 47, 932, DateTimeKind.Local).AddTicks(836), new DateTime(2023, 10, 26, 0, 22, 47, 932, DateTimeKind.Local).AddTicks(836) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 24, 9, 51, 36, 462, DateTimeKind.Local).AddTicks(2712), new DateTime(2023, 10, 24, 0, 15, 36, 462, DateTimeKind.Local).AddTicks(2698) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 51, 36, 462, DateTimeKind.Local).AddTicks(2715), new DateTime(2023, 10, 25, 0, 15, 36, 462, DateTimeKind.Local).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 25, 9, 51, 36, 462, DateTimeKind.Local).AddTicks(2717), new DateTime(2023, 10, 25, 0, 15, 36, 462, DateTimeKind.Local).AddTicks(2718) });

            migrationBuilder.UpdateData(
                table: "Slots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 10, 26, 9, 51, 36, 462, DateTimeKind.Local).AddTicks(2719), new DateTime(2023, 10, 26, 0, 15, 36, 462, DateTimeKind.Local).AddTicks(2720) });
        }
    }
}
