using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeKnits.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Review");

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
