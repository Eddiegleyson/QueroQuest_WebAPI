namespace QueroQuest.Domain.Entities;

using QueroQuest.Domain.Validation;
public sealed class Produto : Entity
{
    private Produto()
    {}
    public Produto(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
    }
    public void Update(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro, int categoriaId)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        CategoriaId = categoriaId;
    }
    public void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl, int estoque, DateTime dataCadastro)
    {
        DomainExceptionValidation.When(hasError: string.IsNullOrEmpty(nome), error: "O Nome é obrigatório.");
        DomainExceptionValidation.When(hasError: nome.Length < 3, error: "O Nome deve ter no minimo 3 caracteres.");

        DomainExceptionValidation.When(hasError: string.IsNullOrEmpty(descricao), error: "descrição obrigatória.");
        DomainExceptionValidation.When(hasError: descricao.Length < 5, error: "Descrição deve ter no minimo 5 carcteres.");
        
        DomainExceptionValidation.When(hasError: preco < 0, error: "Valor do preço invalido, deve ser maior que 0.");

        DomainExceptionValidation.When(hasError: imagemUrl?.Length > 250, error: "O Nome da Imagem não pode exceder 250 caracteres.");

        DomainExceptionValidation.When(hasError: estoque < 0, error: "Estoque inválido");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImagemUrl = imagemUrl;
        Estoque = estoque;
        DataCadastro = dataCadastro;
    }
  
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal? Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public int? Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId {get; set;}
    public Categoria? Categoria {get; set;}
}