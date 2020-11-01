using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Countries.Migrations
{
    public partial class AddCurrencyTableAndAlterCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BestDayToVisit",
                table: "Countries",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Countries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Countries",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Currencies_CurrencyId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "BestDayToVisit",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Countries");
        }
    }
}
