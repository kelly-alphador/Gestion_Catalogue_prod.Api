using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Gestion_catalogue_prod.Domaine.Core.Interface;
using Gestion_catalogue_prod.Infrastructure.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Catalogue_prod.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProduitController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProduitRepository _produitRepository;
        public ProduitController(IUnitOfWork unitOfWork, IProduitRepository produitRepository)
        {
            _unitOfWork = unitOfWork;
            _produitRepository = produitRepository;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var produits = _produitRepository.GetAll();
            return Ok(produits);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProduitCreateDTO produitCreate)
        {
            var produit = new Produit
            {
                Nom = produitCreate.Nom,
                prix = produitCreate.prix,
                CategorieId = produitCreate.CategorieId,
                Quantite = produitCreate.Quantite,
            };
            var response = await _produitRepository.AddAsync(produit);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProduitUpdateDTO produitCreate)
        {
            var produit = new Produit
            {
                Id = produitCreate.Id,
                Nom = produitCreate.Nom,
                prix = produitCreate.prix,
                CategorieId = produitCreate.CategorieId,
                Quantite = produitCreate.Quantite,
            };
            var response = await _produitRepository.UpdateAsync(produit);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _produitRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }

        [HttpGet("categorie/{nom_categorie}")]
        public IActionResult GetByCategorie(string nom_categorie)
        {
            var produits = _produitRepository.GetByCategorie(nom_categorie);
            return Ok(produits);
        }

        [HttpGet("search/{nom}")]
        public IActionResult search(string nom)
        {
            var result = _produitRepository.Search_By_Nom(nom);
            return Ok(result);
        }

        [HttpGet("pagination")]
        public IActionResult Pagination(int page, int pageSize)
        {
            var result = _produitRepository.Pagination(page, pageSize);
            return Ok(result);
        }

        [HttpGet("quantite-par-categorie")]
        public IActionResult Quantite_Produit_By_categorie()
        {
            var result = _produitRepository.Quantite_Produit_By_categorie();
            return Ok(result);
        }

        [HttpGet("tri")]
        public IActionResult TriProduit(string search, bool asc)
        {
            var result = _produitRepository.TriProduit(search, asc);
            return Ok(result);
        }

    }
}
