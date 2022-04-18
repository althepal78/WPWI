using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class fixedRSVP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_AspNetUsers_AppUserId",
                table: "RSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs");

            migrationBuilder.RenameColumn(
                name: "WeddingId",
                table: "RSVPs",
                newName: "WeddingID");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_WeddingId",
                table: "RSVPs",
                newName: "IX_RSVPs_WeddingID");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "RSVPs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_AspNetUsers_AppUserId",
                table: "RSVPs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Weddings_WeddingID",
                table: "RSVPs",
                column: "WeddingID",
                principalTable: "Weddings",
                principalColumn: "WeddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_AspNetUsers_AppUserId",
                table: "RSVPs");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVPs_Weddings_WeddingID",
                table: "RSVPs");

            migrationBuilder.RenameColumn(
                name: "WeddingID",
                table: "RSVPs",
                newName: "WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVPs_WeddingID",
                table: "RSVPs",
                newName: "IX_RSVPs_WeddingId");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "RSVPs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_AspNetUsers_AppUserId",
                table: "RSVPs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVPs_Weddings_WeddingId",
                table: "RSVPs",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId");
        }
    }
}
