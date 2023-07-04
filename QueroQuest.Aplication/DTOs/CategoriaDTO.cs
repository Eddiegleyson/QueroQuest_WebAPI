using System.ComponentModel.DataAnnotations;

namespace QueroQuest.Aplication.DTOs;

public class CategoriaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome da Categoria")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe o nome da Imagem")]
    [MinLength(5)]
    [MaxLength(250)]
    public string? ImagemUrl { get; set; }
}