using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoonBuck.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAndSlotToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CafeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFilled = table.Column<bool>(type: "bit", nullable: false),
                    PayRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Chef" },
                    { 2, 2, "Cashier" },
                    { 3, 3, "Waiter" }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "CafeName", "EndTime", "IsFilled", "PayRate", "StartTime" },
                values: new object[,]
                {
                    { 1, "MoonBuck Toa Payoh", new DateTime(2023, 10, 23, 1, 17, 12, 390, DateTimeKind.Local).AddTicks(3714), false, 9.0, new DateTime(2023, 10, 22, 15, 41, 12, 390, DateTimeKind.Local).AddTicks(3697) },
                    { 2, "MoonBuck Toa Payoh", new DateTime(2023, 10, 24, 1, 17, 12, 390, DateTimeKind.Local).AddTicks(3717), false, 9.0, new DateTime(2023, 10, 23, 15, 41, 12, 390, DateTimeKind.Local).AddTicks(3718) },
                    { 3, "MoonBuck Tampines", new DateTime(2023, 10, 24, 1, 17, 12, 390, DateTimeKind.Local).AddTicks(3720), false, 9.0, new DateTime(2023, 10, 23, 15, 41, 12, 390, DateTimeKind.Local).AddTicks(3721) },
                    { 4, "MoonBuck Hougang", new DateTime(2023, 10, 25, 1, 17, 12, 390, DateTimeKind.Local).AddTicks(3722), false, 9.0, new DateTime(2023, 10, 24, 15, 41, 12, 390, DateTimeKind.Local).AddTicks(3723) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Slots");
        }
    }
}
