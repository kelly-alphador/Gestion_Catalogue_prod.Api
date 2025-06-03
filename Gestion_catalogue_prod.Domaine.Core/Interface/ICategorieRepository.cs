using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;

namespace Gestion_catalogue_prod.Domaine.Core.Interface
{
    public interface ICategorieRepository
    {
        IEnumerable<CategorieDTO> GetAll();
        Task<ApiResponse> Add(Categorie categorie);
        Task<ApiResponse> Update(Categorie categorie);
        Task<ApiResponse> Delete(int id);
        Task<ApiRes<Categorie>> Search(int id);
    }
}
