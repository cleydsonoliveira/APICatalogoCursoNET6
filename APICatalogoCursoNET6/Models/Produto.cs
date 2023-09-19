﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogoCursoNET6.Models
{
    [Table("Produtos")]
    public class Produto : IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, ErrorMessage = "o nome deve conter entre 5 e 20 caracteres", MinimumLength = 5)]
        //[PrimeiraLetraMaiuscula]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(300, ErrorMessage = "A descricao de conter no máximo {1} caracteres")]
        public string? Descricao { get; set; }

        [Required, Column(TypeName = "decimal(10,2)"), Range(1, 1000, ErrorMessage = "O preço deve ser entre {1} e {2}")]
        public decimal Preco { get; set; }

        [Required, StringLength(300)]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(this.Nome))
            {
                var primeiraLetra = this.Nome[0].ToString();
                if (primeiraLetra != primeiraLetra.ToUpper())
                {
                    yield return new ValidationResult("A primeira letra do nome deve ser maúscula",
                        new[] {
                            nameof(this.Nome) }
                        );
                }
            }

            if (this.Estoque <= 0)
            {
                yield return new ValidationResult("O estoque deve ser maior que 0",
                    new[] {
                        nameof(this.Estoque) }
                    );
            }
        }
    }
}
