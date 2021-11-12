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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produit p)
        {
            if (ModelState.IsValid)
            {
                _db.Produits.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
