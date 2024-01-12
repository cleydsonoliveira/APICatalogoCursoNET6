using APICatalogoCursoNET6.Models;

namespace APICatalogoCursoNET6.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
