using APICatalogoCursoNET6.Filters;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogoCursoNET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPreco()
        {
            return _unitOfWork.ProdutoRepository.GetProdutosPorPreco().ToList();
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            var produtos = _unitOfWork.ProdutoRepository.Get().ToList();
            if (produtos != null)
                return Ok(produtos);
            return NotFound("Não há nenhum produto cadastrado.");
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(x => x.ProdutoId == id);
            if (produto == null) return NotFound($"Produto com o id {id} não encontrado.");
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Save([FromBody] Produto produto)
        {
            if (produto != null)
            {
                _unitOfWork.ProdutoRepository.Add(produto);
                _unitOfWork.Commit();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            return BadRequest("Não foi possivel salvar seu produto.");
        }

        [HttpPut("{id:int}")]
        public ActionResult<Produto> Update([FromBody] Produto produto, int id)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest("O id do produto é divergente em relação ao id informado.");
            }

            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(x => x.ProdutoId == id);
            if (produto == null) return NotFound("Produto não localizado");

            _unitOfWork.ProdutoRepository.Delete(produto);
            _unitOfWork.Commit();

            return Ok($"Produto {produto.Nome} com id {produto.ProdutoId} foi removido.");
        }
    }
}
