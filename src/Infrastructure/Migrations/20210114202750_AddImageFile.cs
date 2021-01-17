using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Infrastructure.Migrations
{
    public partial class AddImageFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Shops",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Shops");
        }
    }
}
