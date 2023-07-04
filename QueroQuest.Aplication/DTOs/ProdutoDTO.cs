using System.ComponentModel.DataAnnotations;

namespace QueroQuest.Aplication.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome é Obrigatório.")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A Descricao é Obrigatória.")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Descricao { get; set; }

    [Required(ErrorMessage = "Informe o preço.")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }

  
    [MaxLength(250)]
    public string? ImagemUrl { get; set; }

    [Required(ErrorMessage = "Estoque Obrigatório")]
    [Range(1, 9999)]
    public int Estoque { get; set; }

    [Required(ErrorMessage = "Informe a Data do Cadastro")]
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }
}
