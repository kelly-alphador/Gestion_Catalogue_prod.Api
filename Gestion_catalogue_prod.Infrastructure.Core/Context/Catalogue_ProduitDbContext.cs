using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Gestion_catalogue_prod.Infrastructure.Core.DataConfig;
using Microsoft.EntityFrameworkCore;

namespace Gestion_catalogue_prod.Infrastructure.Core.Context
{
    public class Catalogue_ProduitDbContext:DbContext
    {

        public Catalogue_ProduitDbContext(DbContextOptions<Catalogue_ProduitDbContext> options) : base(options) { }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Produit> Produit { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategorieConfig());
            modelBuilder.ApplyConfiguration(new ProduitConfig());
        }
    }
}
