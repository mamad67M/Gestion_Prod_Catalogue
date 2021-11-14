using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Prod_Catalogue.Migrations
{
    public partial class resolution_conflit4_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "PRODUIT",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "PRODUIT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT",
                column: "CategorieID",
                principalTable: "CATEGORIE",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "PRODUIT",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "CategorieID",
                table: "PRODUIT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT",
                column: "CategorieID",
                principalTable: "CATEGORIE",
                principalColumn: "CategorieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
