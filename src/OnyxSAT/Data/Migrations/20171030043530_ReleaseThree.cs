using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnyxSAT.Data.Migrations
{
    public partial class ReleaseThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Sessions_SessionDateTime",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_SessionDateTime",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "RoomNumber",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                columns: new[] { "DateTime", "RoomNumber" });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    RoomNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScannerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.RoomNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomNumber",
                table: "Sessions",
                column: "RoomNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SessionDateTime_RoomNumber",
                table: "Attendances",
                columns: new[] { "SessionDateTime", "RoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Sessions_SessionDateTime_RoomNumber",
                table: "Attendances",
                columns: new[] { "SessionDateTime", "RoomNumber" },
                principalTable: "Sessions",
                principalColumns: new[] { "DateTime", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Locations_RoomNumber",
                table: "Sessions",
                column: "RoomNumber",
                principalTable: "Locations",
                principalColumn: "RoomNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Sessions_SessionDateTime_RoomNumber",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Locations_RoomNumber",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_RoomNumber",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_SessionDateTime_RoomNumber",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Attendances");

            migrationBuilder.AlterColumn<string>(
                name: "RoomNumber",
                table: "Sessions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_SessionDateTime",
                table: "Attendances",
                column: "SessionDateTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Sessions_SessionDateTime",
                table: "Attendances",
                column: "SessionDateTime",
                principalTable: "Sessions",
                principalColumn: "DateTime",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
