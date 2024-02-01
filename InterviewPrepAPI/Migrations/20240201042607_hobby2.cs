using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewPrepAPI.Migrations
{
    /// <inheritdoc />
    public partial class hobby2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "lastPlayed",
                table: "Hobbies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Hobbies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "lastPlayed",
                table: "Hobbies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
