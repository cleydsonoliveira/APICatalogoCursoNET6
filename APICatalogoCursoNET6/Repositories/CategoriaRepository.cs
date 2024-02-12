using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
        {
            //return Get()
            //    .OrderBy(x => x.Nome)
            //    .Skip((categoriasParameters.PageNumber - 1) * categoriasParameters.PageSize)
            //    .Take(categoriasParameters.PageSize)
            //    .ToList();
            return PagedList<Categoria>.ToPagedList(Get().OrderBy(x => x.Nome), categoriasParameters.PageNumber, categoriasParameters.PageSize);
        }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
