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
        public IActionResult Index(int page = 0, int size = 5, string motcle ="")
        {
            int position = page * size; // pagination
            IEnumerable<Produit> ListeProd = _db.Produits.Where(p =>p.Designation.Contains(motcle))
                .Skip(position)
                .Take(size)
                .Include(c => c.Categorie).ToList();
            // calculer le nombre de pages
            ViewBag.CurrentPage = page;
            int totalPages;
            int nbreProduit = _db.Produits
                .Where(p => p.Designation.Contains(motcle))
                .ToList().Count();
            if ((nbreProduit % size) == 0)
            {
                totalPages = nbreProduit / size;
            }
            else
            {
                totalPages = 1 +(nbreProduit / size);
            }
            ViewBag.totalPages = totalPages;
            return View(ListeProd);
        }
        //public IActionResult Index(int pageNumber =1, int pageSize =4)
        //{
        //    int ExcludeRecords = (pageSize*pageNumber)-pageSize; // pagination
        //    IEnumerable<Produit> ListeProd = _db.Produits.Include(m =>m.Categorie)
        //        .Skip(ExcludeRecords).Take(pageSize);


        //    return View(ListeProd);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            Produit p = new Produit();
            IEnumerable<Categorie> cats = _db.Categories.ToList();
            ViewBag.categorie = cats;
            return View("Create", p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Produit p)
        {
            if (ModelState.IsValid)
            {
                _db.Produits.Add(p);
                _db.SaveChanges();
                TempData["success"] = "Produit ajouter avec succès";
                return RedirectToAction("Index");
            }

            IEnumerable<Categorie> cats = _db.Categories.ToList();
            ViewBag.categorie = cats;
            return View("Create",p);
        }

        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if (id==0 || id == null)
            {
                return NotFound();
            }
            var prod = _db.Produits.SingleOrDefault(p =>p.ProduitID == id);
            if ( prod == null)
            {
                return NotFound();

            }
            IEnumerable<Categorie> cats = _db.Categories.ToList();
            ViewBag.categorie = cats;
            return View(prod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produit p)
        {
            if (ModelState.IsValid)
            {
                _db.Produits.Update(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<Categorie> cats = _db.Categories.ToList();
            ViewBag.categorie = cats;
            return View(p);
        }
    }
}
