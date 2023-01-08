using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKnits.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredFromUserIdInReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Review",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
