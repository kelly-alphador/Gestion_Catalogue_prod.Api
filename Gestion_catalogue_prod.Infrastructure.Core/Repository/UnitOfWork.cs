using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.Interface;
using Gestion_catalogue_prod.Infrastructure.Core.Context;
using Gestion_catalogue_prod.Infrastructure.Core.Factory;

namespace Gestion_catalogue_prod.Infrastructure.Core.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly Catalogue_ProduitDbContext _context;
        public UnitOfWork(Catalogue_ProduitDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
