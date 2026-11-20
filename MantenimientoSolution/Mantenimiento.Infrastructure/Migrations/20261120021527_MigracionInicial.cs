using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mantenimiento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceOrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceOrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceOrderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MaintenanceOrderTypesId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrder_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrder_MaintenanceOrderStatus_MaintenanceOrderStatusId",
                        column: x => x.MaintenanceOrderStatusId,
                        principalTable: "MaintenanceOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceOrder_MaintenanceOrderTypes_MaintenanceOrderTypesId",
                        column: x => x.MaintenanceOrderTypesId,
                        principalTable: "MaintenanceOrderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MaintenanceOrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En Proceso" },
                    { 3, "Completada" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceOrderTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Preventivo" },
                    { 2, "Correctivo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrder_EquipmentId",
                table: "MaintenanceOrder",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrder_MaintenanceOrderStatusId",
                table: "MaintenanceOrder",
                column: "MaintenanceOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceOrder_MaintenanceOrderTypesId",
                table: "MaintenanceOrder",
                column: "MaintenanceOrderTypesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceOrder");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "MaintenanceOrderStatus");

            migrationBuilder.DropTable(
                name: "MaintenanceOrderTypes");
        }
    }
}
