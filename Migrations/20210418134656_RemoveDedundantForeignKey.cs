using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchDatabaseAPI.Migrations
{
    public partial class RemoveDedundantForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "ImageForeignKey",
                table: "Image",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image",
                column: "ImageForeignKey",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "ImageForeignKey",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image",
                column: "ImageForeignKey",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
