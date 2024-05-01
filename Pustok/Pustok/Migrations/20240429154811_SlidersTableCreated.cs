using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.Migrations
{
    /// <inheritdoc />
    public partial class SlidersTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BookImages");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "BookImages");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BtnText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BtnUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BookImages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "BookImages",
                type: "datetime2",
                nullable: true);
        }
    }
}
