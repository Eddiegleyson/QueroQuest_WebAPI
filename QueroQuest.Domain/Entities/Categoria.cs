namespace QueroQuest.Domain.Entities;

using QueroQuest.Domain.Validation;

public sealed class Categoria : Entity
{
    public Categoria(string nome, string imagemUrl)
    {
        ValidateDomain(nome,imagemUrl);
    }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
    public ICollection<Produto> Produtos {get; set;} 

    public void ValidateDomain(string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
            "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
            "Nome da imagem inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3,
           "O nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(imagemUrl.Length < 5,
            "Nome da imagem deve ter no mínimo 5 caracteres");

        Nome = nome;
        ImagemUrl = imagemUrl;
    }
}