using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hallowe_backend.Migrations
{
    /// <inheritdoc />
    public partial class MoveTimeSlotToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_TimeSlots_TimeSlotId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Locations_TimeSlotId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Locations");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Locations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "Locations",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Locations",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Locations");

            migrationBuilder.AddColumn<Guid>(
                name: "TimeSlotId",
                table: "Locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TimeSlotId",
                table: "Locations",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_TimeSlots_TimeSlotId",
                table: "Locations",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
