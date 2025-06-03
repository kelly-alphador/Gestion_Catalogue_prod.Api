using System.Threading.Tasks;
using Gestion_catalogue_prod.Domaine.Core.DTO;
using Gestion_catalogue_prod.Domaine.Core.Entities;
using Gestion_catalogue_prod.Domaine.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Catalogue_prod.Api.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class CategoriController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategorieRepository _categorieRepository;
        public CategoriController(IUnitOfWork unitOfWork,ICategorieRepository categorieRepository)
        {
            _unitOfWork = unitOfWork;
            _categorieRepository = categorieRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var response=_categorieRepository.GetAll();
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategorieCreateDto  categorieCreateDto)
        {
            var categorie = new Categorie
            {
                Nom = categorieCreateDto.Nom,
            };
            var response=await _categorieRepository.Add(categorie); 
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategorieUpdateDto categorieUpdate)
        {
            var categorie = new Categorie
            {
                Id = categorieUpdate.Id,
                Nom = categorieUpdate.Nom,
            };
            var response=await _categorieRepository.Update(categorie);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var response=await _categorieRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response=await _categorieRepository.Search(id);
            return Ok(response);
        }
    }
}
