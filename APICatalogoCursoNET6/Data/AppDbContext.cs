﻿using APICatalogoCursoNET6.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogoCursoNET6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
