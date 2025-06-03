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
    public class CategorieConfig:IEntityTypeConfiguration<Categorie>
    {
        public void Configure(EntityTypeBuilder<Categorie> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
