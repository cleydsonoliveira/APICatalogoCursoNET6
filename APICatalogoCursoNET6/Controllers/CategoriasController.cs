using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/saudacao/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriesProducts()
        {
            return _context.Categorias.Take(10).Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).AsNoTracking().ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            var categorias = _context.Categorias.Take(10).AsNoTracking().ToList();
            if (categorias == null) return NotFound();

            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "Obter Categoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(x => x.CategoriaId == id);
            if (categoria == null) return NotFound("Categoria não encontrada");

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Save([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("Obter produto", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Categoria> Update([FromBody] Categoria categoria, int id)
        {
            if (categoria.CategoriaId != id)
            {
                return BadRequest();
            }


            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Remove(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);

            if (categoria == null) return NotFound("Categoria não encontrada");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
    }
}
