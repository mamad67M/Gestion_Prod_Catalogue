using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestion_Prod_Catalogue.Migrations
{
    public partial class resolution_conflit3_BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomCatalogue",
                table: "CATEGORIE",
                newName: "NomCategorie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomCategorie",
                table: "CATEGORIE",
                newName: "NomCatalogue");
        }
    }
}
