using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hallowe_backend.Migrations
{
    /// <inheritdoc />
    public partial class TemporarilyRemoveTimeSlotFromDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistredParticipants_TimeSlots_TimeSlotId",
                table: "RegistredParticipants");

            migrationBuilder.DropIndex(
                name: "IX_RegistredParticipants_TimeSlotId",
                table: "RegistredParticipants");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "RegistredParticipants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TimeSlotId",
                table: "RegistredParticipants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RegistredParticipants_TimeSlotId",
                table: "RegistredParticipants",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistredParticipants_TimeSlots_TimeSlotId",
                table: "RegistredParticipants",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
