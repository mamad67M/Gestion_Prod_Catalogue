using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Prod_Catalogue.Models
{
    [Table("PRODUIT")]
    public class Produit
    {
        [Key]
        public int ProduitID { get; set; }
        [StringLength(50)]
        [Required]
        public string Designation { get; set; }
        [Required]
        [Range(100, 2000)]
        public double Prix { get; set; }
        public int Quantite { get; set; }
        
       // public int CategorieID { get; set; }
        // propriete de navigation (Lezy Loading)
        public virtual Categorie Categorie { get; set; }
    }
}
