using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hallowe_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Participants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Participants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Participants",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Participants");
        }
    }
}
