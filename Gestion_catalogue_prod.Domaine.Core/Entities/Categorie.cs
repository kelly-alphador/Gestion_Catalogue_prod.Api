using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gestion_catalogue_prod.Domaine.Core.Entities
{
    public class Categorie
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nom { get; set; }
        [JsonIgnore]
        public ICollection<Produit> ProduitList { get; set; }=new List<Produit>();
    }
}
