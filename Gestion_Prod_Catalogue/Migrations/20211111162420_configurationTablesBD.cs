using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Prod_Catalogue.Migrations
{
    public partial class configurationTablesBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produits_Catalogues_CatalogueID",
                table: "Produits");

            migrationBuilder.DropTable(
                name: "Catalogues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produits",
                table: "Produits");

            migrationBuilder.DropIndex(
                name: "IX_Produits_CatalogueID",
                table: "Produits");

            migrationBuilder.DropColumn(
                name: "CatalogueID",
                table: "Produits");

            migrationBuilder.RenameTable(
                name: "Produits",
                newName: "PRODUIT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUIT",
                table: "PRODUIT",
                column: "ProduitID");

            migrationBuilder.CreateTable(
                name: "CATEGORIE",
                columns: table => new
                {
                    CatalogueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCatalogue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIE", x => x.CatalogueID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUIT_CATEGORIE_CategorieID",
                table: "PRODUIT");

            migrationBuilder.DropTable(
                name: "CATEGORIE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUIT",
                table: "PRODUIT");

            migrationBuilder.DropIndex(
                name: "IX_PRODUIT_CategorieID",
                table: "PRODUIT");

            migrationBuilder.RenameTable(
                name: "PRODUIT",
                newName: "Produits");

            migrationBuilder.AddColumn<int>(
                name: "CatalogueID",
                table: "Produits",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produits",
                table: "Produits",
                column: "ProduitID");

            migrationBuilder.CreateTable(
                name: "Catalogues",
                columns: table => new
                {
                    CatalogueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCatalogue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogues", x => x.CatalogueID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_CatalogueID",
                table: "Produits",
                column: "CatalogueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produits_Catalogues_CatalogueID",
                table: "Produits",
                column: "CatalogueID",
                principalTable: "Catalogues",
                principalColumn: "CatalogueID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
