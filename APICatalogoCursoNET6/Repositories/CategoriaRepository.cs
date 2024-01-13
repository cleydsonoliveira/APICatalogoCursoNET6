using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext) { }
        public IEnumerable<Categoria> GetCategoriasProdutos()
        {
            return Get().Include(x => x.Produtos);
        }
    }
}
