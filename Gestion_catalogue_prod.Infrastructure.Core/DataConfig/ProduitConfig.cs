using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestion_catalogue_prod.Infrastructure.Core.DataConfig
{
    public class ProduitConfig:IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(p => p.prix)
                .HasPrecision(10,2)
                .IsRequired();
            builder.Property(p => p.Quantite)
                .IsRequired()
                .HasMaxLength(3);
            builder.HasOne(p => p.Categorie)
                .WithMany(p => p.ProduitList)
                .HasForeignKey(p => p.CategorieId);
                
                
        }

    }
}
