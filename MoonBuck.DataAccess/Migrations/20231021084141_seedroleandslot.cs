using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoonBuck.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedroleandslot : Migration
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
                    PayRate = table.Column<double>(type: "float", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "CafeName", "EndTime", "IsFilled", "PayRate", "RoleId", "StartTime" },
                values: new object[,]
                {
                    { 1, "MoonBuck Toa Payoh", new DateTime(2023, 10, 23, 2, 17, 41, 326, DateTimeKind.Local).AddTicks(4691), false, 9.0, 1, new DateTime(2023, 10, 22, 16, 41, 41, 326, DateTimeKind.Local).AddTicks(4677) },
                    { 2, "MoonBuck Toa Payoh", new DateTime(2023, 10, 24, 2, 17, 41, 326, DateTimeKind.Local).AddTicks(4693), false, 9.0, 2, new DateTime(2023, 10, 23, 16, 41, 41, 326, DateTimeKind.Local).AddTicks(4693) },
                    { 3, "MoonBuck Tampines", new DateTime(2023, 10, 24, 2, 17, 41, 326, DateTimeKind.Local).AddTicks(4695), false, 9.0, 2, new DateTime(2023, 10, 23, 16, 41, 41, 326, DateTimeKind.Local).AddTicks(4695) },
                    { 4, "MoonBuck Hougang", new DateTime(2023, 10, 25, 2, 17, 41, 326, DateTimeKind.Local).AddTicks(4697), false, 9.0, 2, new DateTime(2023, 10, 24, 16, 41, 41, 326, DateTimeKind.Local).AddTicks(4697) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slots_RoleId",
                table: "Slots",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
