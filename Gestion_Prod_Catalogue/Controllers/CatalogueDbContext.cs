using Gestion_Prod_Catalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Prod_Catalogue.Controllers
{
    public class CatalogueDbContext: DbContext
    {
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options): base(options)
        {

        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }

    }
}
