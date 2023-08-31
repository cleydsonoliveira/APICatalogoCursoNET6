using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogoCursoNET6.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Snacks', 'snacks.jpg')");
            migrationBuilder.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categorias");
        }
    }
}
