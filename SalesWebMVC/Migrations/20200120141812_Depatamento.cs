using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class Depatamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departamants_depId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_depId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "depId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartamantsId",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartamantsId",
                table: "Seller",
                column: "DepartamantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departamants_DepartamantsId",
                table: "Seller",
                column: "DepartamantsId",
                principalTable: "Departamants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departamants_DepartamantsId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartamantsId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartamantsId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "depId",
                table: "Seller",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_depId",
                table: "Seller",
                column: "depId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departamants_depId",
                table: "Seller",
                column: "depId",
                principalTable: "Departamants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
