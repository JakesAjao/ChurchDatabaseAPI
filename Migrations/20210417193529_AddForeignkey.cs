using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchDatabaseAPI.Migrations
{
    public partial class AddForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageForeignKey",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageForeignKey",
                table: "Image");
        }
    }
}
