namespace QueroQuest.Domain.Interfaces;

using QueroQuest.Domain.Entities;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorPreco();
}
