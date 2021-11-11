using Gestion_Prod_Catalogue.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Prod_Catalogue.Controllers
{
    public class ProduitController : Controller
    {
        private readonly CatalogueDbContext _db;

        public ProduitController(CatalogueDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Produit> ListeProd = _db.Produits;
            return View(ListeProd);
        }
    }
}
