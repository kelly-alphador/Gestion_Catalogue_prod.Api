﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_catalogue_prod.Domaine.Core.Entities
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Decimal prix {  get; set; }
        public int Quantite { get; set; }
        public Categorie Categorie { get; set; }
        public int CategorieId {  get; set; }
    }
}
