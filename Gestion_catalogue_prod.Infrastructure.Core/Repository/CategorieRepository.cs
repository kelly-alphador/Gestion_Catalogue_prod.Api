using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Gestion_catalogue_prod.Domaine.Core.Interface;
using Gestion_catalogue_prod.Infrastructure.Core.Context;

namespace Gestion_catalogue_prod.Infrastructure.Core.Repository
{
    public class CategorieRepository:ICategorieRepository
    {
        private readonly Catalogue_ProduitDbContext _context;
        public CategorieRepository(Catalogue_ProduitDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CategorieDTO> GetAll()
        {
            return _context.Categorie.Select(c => new CategorieDTO
            {
                Id = c.Id,
                Nom = c.Nom,
            });
        }
        public async Task<ApiResponse> Add(Categorie categorie)
        {
            await _context.AddAsync(categorie);
            return new ApiResponse
            {
                sucess = true,
                Message = "Donnee enregistrer avec sucees"
            };
        }
        public async Task<ApiResponse> Update(Categorie categorie)
        {
            var exist = await _context.Categorie.FindAsync(categorie.Id);
            if (exist != null)
            {
                exist.Id = categorie.Id;
                exist.Nom = categorie.Nom;
                exist.ProduitList = categorie.ProduitList;
                return new ApiResponse
                {
                    sucess = true,
                    Message = "Donnees Modifier avec success"
                };
            }
            else
            {
                return new ApiResponse
                {
                    sucess = false,
                    Message = "Id innexistant"
                };
            }
        }
        public async Task<ApiResponse> Delete(int id)
        {
            var exist = await _context.Categorie.FindAsync(id);
            if (exist != null)
            {
                _context.Categorie.Remove(exist);
                return new ApiResponse
                {
                    sucess = true,
                    Message = "Donnees supprimer avec success"
                };
            }
            else
            {
                return new ApiResponse
                {
                    sucess = false,
                    Message = "Id innexistant"
                };
            }
        }
        public async Task<ApiRes<Categorie>> Search(int id)
        {
            var exist = await _context.Categorie.FindAsync(id);
            if(exist!=null)
            {
                return new ApiRes<Categorie>
                {
                    sucess = true,
                    data = exist
                };
            }
            else
            {
                return new ApiRes<Categorie>
                {
                    sucess = true,
                    Message="cette produit n'existe pas"
                };
            }
        }
    }
}
