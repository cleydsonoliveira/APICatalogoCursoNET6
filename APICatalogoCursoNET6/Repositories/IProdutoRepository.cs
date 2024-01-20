﻿using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Pagination;

namespace APICatalogoCursoNET6.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetAll(ProdutosParameters produtosParameters);
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
