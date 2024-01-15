using APICatalogoCursoNET6.DTOs;
using APICatalogoCursoNET6.Filters;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogoCursoNET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosPreco()
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutosPorPreco().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            if (produtos == null) return NotFound("Não há nenhum produto cadastrado.");
            return produtosDTO;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<ProdutoDTO>> GetAll()
        {
            var produtos = _unitOfWork.ProdutoRepository.Get().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            if (produtos != null) return produtosDTO;
            return NotFound("Não há nenhum produto cadastrado.");
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<ProdutoDTO> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(x => x.ProdutoId == id);
            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
            if (produto == null) return NotFound($"Produto com o id {id} não encontrado.");
            return Ok(produtoDTO);
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Save([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _unitOfWork.ProdutoRepository.Add(produto);
            _unitOfWork.Commit();

            var produtoDTO2 = _mapper.Map<ProdutoDTO>(produto);
            return new CreatedAtRouteResult("ObterProduto", new { id = produtoDTO2.ProdutoId }, produtoDTO2);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Produto> Update([FromBody] ProdutoDTO produtoDTO, int id)
        {
            if (id != produtoDTO.ProdutoId)
            {
                return BadRequest("O id do produto é divergente em relação ao id informado.");
            }
            var produto = _mapper.Map<Produto>(produtoDTO);

            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();

            var produtoDTO2 = _mapper.Map<ProdutoDTO>(produto);
            return Ok(produtoDTO2);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(x => x.ProdutoId == id);
            if (produto == null) return NotFound("Produto não localizado");

            _unitOfWork.ProdutoRepository.Delete(produto);
            _unitOfWork.Commit();

            return Ok($"Produto {produto.Nome} com id {produto.ProdutoId} foi removido.");
        }
    }
}
