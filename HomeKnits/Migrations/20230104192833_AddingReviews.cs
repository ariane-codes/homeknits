using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKnits.Migrations
{
    /// <inheritdoc />
    public partial class AddingReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Review",
                newName: "ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Review",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technique",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Technique",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Review",
                newName: "ProductID");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_User",
                table: "Review",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
