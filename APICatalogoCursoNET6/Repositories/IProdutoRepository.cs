using APICatalogoCursoNET6.Models;

namespace APICatalogoCursoNET6.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
