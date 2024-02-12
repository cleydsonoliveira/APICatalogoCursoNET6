using APICatalogoCursoNET6.DTOs;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Pagination;
using APICatalogoCursoNET6.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APICatalogoCursoNET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoriasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriesProducts()
        {
            var categoriasProdutos = _unitOfWork.CategoriaRepository.GetCategoriasProdutos();
            var categoriasdto = _mapper.Map<List<CategoriaDTO>>(categoriasProdutos);
            return Ok(categoriasdto);

        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> GetAll([FromQuery] CategoriasParameters categoriasParameters)
        {
            var categorias = _unitOfWork.CategoriaRepository.GetCategorias(categoriasParameters);
            if (categorias == null) return NotFound();

            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HasNext,
                categorias.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var categoriasDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
            return Ok(categoriasDTO);
        }

        [HttpGet("{id:int}", Name = "Obter Categoria")]
        public ActionResult<CategoriaDTO> Get(int id)
        {
            var categoria = _unitOfWork.CategoriaRepository.GetById(x => x.CategoriaId == id);
            if (categoria == null) return NotFound("Categoria não encontrada");
            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDTO);
        }

        [HttpPost]
        public ActionResult<CategoriaDTO> Save([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null) return BadRequest();
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _unitOfWork.CategoriaRepository.Add(categoria);
            var categoriaDTO2 = _mapper.Map<CategoriaDTO>(categoria);

            return new CreatedAtRouteResult("Obter produto", new { id = categoriaDTO2.CategoriaId }, categoriaDTO2);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoriaDTO> Update([FromBody] CategoriaDTO categoriaDTO, int id)
        {
            if (categoriaDTO.CategoriaId != id)
            {
                return BadRequest();
            }
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _unitOfWork.CategoriaRepository.Update(categoria);
            var categoriaDTO2 = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoriaDTO2);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoriaDTO> Remove(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null) return NotFound("Categoria não encontrada");
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _unitOfWork.CategoriaRepository.Delete(categoria);

            return Ok($"Categoria {categoriaDTO.Nome} com id {categoriaDTO.CategoriaId} foi removidA.");
        }
    }
}
