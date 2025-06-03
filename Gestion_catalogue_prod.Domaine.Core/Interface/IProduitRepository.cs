using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;

namespace Gestion_catalogue_prod.Domaine.Core.Interface
{
    public interface IProduitRepository
    {
        IEnumerable<ProduitDTO> GetAll();
        Task<ApiResponse> AddAsync(Produit produit);
        Task<ApiResponse> UpdateAsync(Produit produit);
        Task<ApiResponse> DeleteAsync(int id);
        IEnumerable<ProduitDTO> GetByCategorie(string nom);
        IEnumerable<ProduitDTO> Search_By_Nom(string nom);
        IEnumerable<ProduitDTO> Pagination(int page, int pageSize);
        IEnumerable<Quantite_prodBycategorie> Quantite_Produit_By_categorie();
        IEnumerable<ProduitDTO> TriProduit(string critere, bool asc);
    }
}
