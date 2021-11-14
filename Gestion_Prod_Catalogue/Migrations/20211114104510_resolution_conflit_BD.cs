using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Prod_Catalogue.Migrations
{
    public partial class resolution_conflit_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT");

            migrationBuilder.DropIndex(
                name: "IX_PRODUIT_CategorieID",
                table: "PRODUIT");

            migrationBuilder.RenameColumn(
                name: "CategorieID",
                table: "PRODUIT",
                newName: "CatalogueID");

            migrationBuilder.AddColumn<int>(
                name: "CategorieCatalogueID",
                table: "PRODUIT",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUIT_CategorieCatalogueID",
                table: "PRODUIT",
                column: "CategorieCatalogueID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieCatalogueID",
                table: "PRODUIT",
                column: "CategorieCatalogueID",
                principalTable: "CATEGORIE",
                principalColumn: "CatalogueID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieCatalogueID",
                table: "PRODUIT");

            migrationBuilder.DropIndex(
                name: "IX_PRODUIT_CategorieCatalogueID",
                table: "PRODUIT");

            migrationBuilder.DropColumn(
                name: "CategorieCatalogueID",
                table: "PRODUIT");

            migrationBuilder.RenameColumn(
                name: "CatalogueID",
                table: "PRODUIT",
                newName: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUIT_CategorieID",
                table: "PRODUIT",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT",
                column: "CategorieID",
                principalTable: "CATEGORIE",
                principalColumn: "CatalogueID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
