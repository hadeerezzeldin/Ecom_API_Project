using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Removetherelationbetweenassressandappuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_Addressid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Addressid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Addressid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Addressid",
                table: "AspNetUsers",
                column: "Addressid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_Addressid",
                table: "AspNetUsers",
                column: "Addressid",
                principalTable: "Addresses",
                principalColumn: "id");
        }
    }
}
