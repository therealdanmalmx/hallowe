using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hallowe_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_TimeSlot_TimeSlotId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlot_Participant_ParticipantId",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlot_ParticipantId",
                table: "TimeSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "TimeSlot");

            migrationBuilder.RenameTable(
                name: "TimeSlot",
                newName: "TimeSlots");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_TimeSlotId",
                table: "Participants",
                newName: "IX_Participants_TimeSlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_TimeSlots_TimeSlotId",
                table: "Participants",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_TimeSlots_TimeSlotId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeSlots",
                table: "TimeSlots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "TimeSlots",
                newName: "TimeSlot");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_TimeSlotId",
                table: "Participant",
                newName: "IX_Participant_TimeSlotId");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "TimeSlot",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeSlot",
                table: "TimeSlot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_ParticipantId",
                table: "TimeSlot",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_TimeSlot_TimeSlotId",
                table: "Participant",
                column: "TimeSlotId",
                principalTable: "TimeSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlot_Participant_ParticipantId",
                table: "TimeSlot",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id");
        }
    }
}
