using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Infrastructure.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gestion_catalogue_prod.Infrastructure.Core.Factory
{
    public class CatalogueProduitFactory:IDesignTimeDbContextFactory<Catalogue_ProduitDbContext>
    {
        public Catalogue_ProduitDbContext CreateDbContext(string[] args)
        {
            var options=new DbContextOptionsBuilder<Catalogue_ProduitDbContext>();
            options.UseSqlServer("Server=DESKTOP-1PCHEEU\\SQLEXPRESS;Database=Catalogue_Produit;Trusted_Connection=True;TrustServerCertificate=True");
            return new Catalogue_ProduitDbContext(options.Options);
        }
    }
}
