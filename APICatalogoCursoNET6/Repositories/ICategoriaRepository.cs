﻿using APICatalogoCursoNET6.Models;
using APICatalogoCursoNET6.Pagination;

namespace APICatalogoCursoNET6.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        IEnumerable<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
        IEnumerable<Categoria> GetCategoriasProdutos();
    }
}
