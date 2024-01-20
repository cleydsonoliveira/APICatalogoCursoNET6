using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public IEnumerable<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
        {
            return GetCategorias(categoriasParameters)
                .OrderBy(x => x.Nome)
                .Skip((categoriasParameters.PageNumber - 1) * categoriasParameters.PageSize)
                .Take(categoriasParameters.PageSize)
                .ToList();
        }

        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
