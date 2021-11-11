using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Prod_Catalogue.Models
{
   [Table("CATEGORIE")]
    public class Categorie
    {
        public int CatalogueID { get; set; }
        [StringLength(30)]
        public string  NomCatalogue { get; set; }
        // propriete de navigation (Lezy Loading)
        public virtual ICollection<Produit> ListeProd { get; set; }
    }
}
