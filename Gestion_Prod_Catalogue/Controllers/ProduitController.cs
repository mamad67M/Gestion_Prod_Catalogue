using Gestion_Prod_Catalogue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(int page =0, int size =5)
        {
            int position = page * size; // pagination
            IEnumerable<Produit> ListeProd = _db.Produits.Skip(position).Take(size);
            // calculer le nombre de pages
            ViewBag.CurrentPage = page;
            int totalPages = _db.Produits.Count()/size;
            ViewBag.totalPages = totalPages;
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
                TempData["success"] = "Produit ajouter avec succès";
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
