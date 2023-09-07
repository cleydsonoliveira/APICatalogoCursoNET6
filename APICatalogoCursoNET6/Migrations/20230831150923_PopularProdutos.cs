using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogoCursoNET6.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Coca-Cola Lata 350ml', 'Refrigerante sabor cola', 5.0, 'coca-lata.jpg', 30, now(), 1)");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Pringles', 'Batata frita crocrante', 12.5, 'pringles.jpg', 45, now(), 2)");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Pudim', 'Pudim caseiro', 4.50, 'pudim.jpg', 10, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
