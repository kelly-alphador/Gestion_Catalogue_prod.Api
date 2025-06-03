using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.Entities;

namespace Gestion_catalogue_prod.Domaine.Core.DTO
{
    public class ProduitDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Decimal prix { get; set; }
        public int Quantite { get; set; }
        public CategorieDTO Categorie { get; set; }
        
    }
}
