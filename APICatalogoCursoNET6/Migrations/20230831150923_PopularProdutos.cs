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
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Coca-Cola Lata 350ml', 'Refrigerante sabor cola', 5.0, 'coca-lata.jpg', 30, now(), 1");
            migrationBuilder.Sql("Insert into Produtos(Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values('Pringles')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
