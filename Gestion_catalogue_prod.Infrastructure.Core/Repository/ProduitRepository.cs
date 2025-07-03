using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Gestion_catalogue_prod.Domaine.Core.Interface;
using Gestion_catalogue_prod.Infrastructure.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace Gestion_catalogue_prod.Infrastructure.Core.Repository
{
    public class ProduitRepository:IProduitRepository
    {
        private readonly Catalogue_ProduitDbContext _dbContext;
        public ProduitRepository(Catalogue_ProduitDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ProduitDTO> GetAll()
        {
            return _dbContext.Produit
      .Include(p => p.Categorie) // Charger la catégorie liée pour éviter les erreurs
      .Select(p => new ProduitDTO
      {
          
          Id = p.Id,
          Nom = p.Nom,
          prix = p.prix,
          
          Quantite = p.Quantite,
          Categorie = new CategorieDTO
          {
              Id = p.Categorie.Id,
              Nom = p.Categorie.Nom
          }
      })
      .ToList();
        }
        public IEnumerable<ProduitDTO> GetByCategorie(string nom)
        {
            return _dbContext.Produit
                .Include(p => p.Categorie)
                .Where(p => p.Categorie.Nom == nom)
                .Select(p => new ProduitDTO
                {
                    Id = p.Id,
                    Nom = p.Nom,
                    prix = p.prix,
                    Quantite = p.Quantite,
                    Categorie = new CategorieDTO
                    {
                        Id = p.Categorie.Id,
                        Nom = p.Categorie.Nom
                    }
                })
                .ToList();
        }

        public IEnumerable<ProduitDTO> Search_By_Nom(string nom)
        {
            return _dbContext.Produit.Where(p => p.Nom.ToLower().Contains(nom.ToLower())).Select(p => new ProduitDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                prix = p.prix,
                Quantite = p.Quantite,
                 Categorie = new CategorieDTO
                 {
                     Id = p.Categorie.Id,
                     Nom = p.Categorie.Nom
                 }
            }).ToList();
        }
        public IEnumerable<ProduitDTO> Pagination(int page, int pageSize)
        {
            return _dbContext.Produit.Skip((page-1)*pageSize).Take(pageSize).Select(p=>new ProduitDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                prix = p.prix,
                Quantite = p.Quantite,
                Categorie = new CategorieDTO
                {
                    Id = p.Categorie.Id,
                    Nom = p.Categorie.Nom
                }
            }).ToList();
        }
        public IEnumerable<Quantite_prodBycategorie> Quantite_Produit_By_categorie()
        {
            return _dbContext.Produit.GroupBy(p => p.Categorie.Nom).Select(p => new Quantite_prodBycategorie
            {
                Nom_categorie = p.Key,
                Qantite_Total = p.Sum(p => p.Quantite)
            }).ToList();
        }
        public async Task<ApiResponse> AddAsync(Produit produit)
        {
            await _dbContext.AddAsync(produit);
            return new ApiResponse
            {
                sucess = true,
                Message = "Donnee enregistrer avec sucees"
            };
        }
        public async Task<ApiResponse> UpdateAsync(Produit produit)
        {
            var exist = await _dbContext.Produit.FindAsync(produit.Id);
            if (exist != null)
            {
                exist.Nom = produit.Nom;
                exist.prix = produit.prix;
                exist.Quantite = produit.Quantite;
                exist.CategorieId = produit.CategorieId;
                exist.Categorie = produit.Categorie;
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
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            var exist = await _dbContext.Produit.FindAsync(id);
            if (exist != null)
            {
                _dbContext.Produit.Remove(exist);
                return new ApiResponse
                {
                    sucess = true,
                    Message = "Donnee supprimer  avec succees"
                };
            }
            else
            {
                return new ApiResponse
                {
                    sucess = false,
                    Message = "id inexistant"
                };
            }
        }
        public IEnumerable<ProduitDTO> TriProduit(string critere, bool asc)
        {
            IQueryable<Produit> query = _dbContext.Produit.Include(p => p.Categorie);

            switch (critere.ToLower())
            {
                case "nom":
                    query = asc ? query.OrderBy(p => p.Nom) : query.OrderByDescending(p => p.Nom);
                    break;
                case "prix":
                    query = asc ? query.OrderBy(p => p.prix) : query.OrderByDescending(p => p.prix);
                    break;
                case "quantite":
                    query = asc ? query.OrderBy(p => p.Quantite) : query.OrderByDescending(p => p.Quantite);
                    break;
                default:
                    // facultatif : trier par nom par défaut
                    query = asc ? query.OrderBy(p => p.Nom) : query.OrderByDescending(p => p.Nom);
                    break;
            }

            return query.Select(p => new ProduitDTO
            {
                Id = p.Id,
                Nom = p.Nom,
                prix = p.prix,
                Quantite = p.Quantite,
                Categorie = new CategorieDTO
                {
                    Id = p.Categorie.Id,
                    Nom = p.Categorie.Nom
                }
            }).ToList();
        }

    }
}
