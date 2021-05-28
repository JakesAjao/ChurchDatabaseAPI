using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchDatabaseAPI.Migrations
{
    public partial class AddImageForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Membership_ImageForeignKey",
                table: "Membership");

            migrationBuilder.AlterColumn<int>(
                name: "ImageForeignKey",
                table: "Image",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membership_ImageForeignKey",
                table: "Membership",
                column: "ImageForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageForeignKey",
                table: "Image",
                column: "ImageForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image",
                column: "ImageForeignKey",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Membership_ImageForeignKey",
                table: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_Image_ImageForeignKey",
                table: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "ImageForeignKey",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Membership_ImageForeignKey",
                table: "Membership",
                column: "ImageForeignKey",
                unique: true);
        }
    }
}
