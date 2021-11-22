using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChurchDatabaseAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    EventDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(nullable: false),
                    emailAddress = table.Column<string>(nullable: true),
                    subject = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    searchKey = table.Column<string>(nullable: true),
                    mobilePhone = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    responseTime = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    statusMessage = table.Column<string>(nullable: true),
                    serviceType = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    MobilePhone1 = table.Column<string>(nullable: true),
                    MobilePhone2 = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NextOfKin = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    WeddingAnniversary = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true),
                    PrayerRequest = table.Column<string>(nullable: true),
                    SendNewLetter = table.Column<string>(nullable: true),
                    ImageForeignKey = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Member = table.Column<string>(nullable: true),
                    Interest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ImageForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Membership_ImageForeignKey",
                        column: x => x.ImageForeignKey,
                        principalTable: "Membership",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ImageForeignKey",
                table: "Image",
                column: "ImageForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_ImageForeignKey",
                table: "Membership",
                column: "ImageForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Membership_Image_ImageForeignKey",
                table: "Membership",
                column: "ImageForeignKey",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Membership_ImageForeignKey",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
