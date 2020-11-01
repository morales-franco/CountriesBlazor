using Microsoft.EntityFrameworkCore.Migrations;

namespace Countries.Migrations
{
    public partial class AlterCountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Countries",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
