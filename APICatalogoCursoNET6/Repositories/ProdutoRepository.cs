using APICatalogoCursoNET6.Data;
using APICatalogoCursoNET6.Models;

namespace APICatalogoCursoNET6.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Produto> GetProdutosPorPreco()
        {
            return Get().OrderBy(x => x.Preco).ToList();
        }
    }
}
