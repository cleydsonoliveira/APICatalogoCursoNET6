using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Filters;
using APICatalogoCursoNET6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            var produtos = _context.Produtos.Take(10).AsNoTracking().ToList();
            if (produtos != null)
                return Ok(produtos);
            return NotFound();
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            //throw new Exception("Deu erro aqui pae");
            var produto = _context.Produtos.Take(10).AsNoTracking().FirstOrDefault(x => x.ProdutoId == id);
            if (produto == null) return NotFound("Produto não encontrado");
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Save([FromBody] Produto produto)
        {
            if (produto != null)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            return BadRequest("Não foi possivel salvar seu produto");
        }

        [HttpPut("{id:int}")]
        public ActionResult<Produto> Update([FromBody] Produto produto, int id)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            if (produto == null) return NotFound("Produto não localizado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
