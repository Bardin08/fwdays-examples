using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Specifications.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "DigitalItems");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Mark = table.Column<double>(type: "double precision", nullable: false),
                    DigitalContentItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_DigitalItems_DigitalContentItemId",
                        column: x => x.DigitalContentItemId,
                        principalTable: "DigitalItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_DigitalContentItemId",
                table: "Rating",
                column: "DigitalContentItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "DigitalItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
