namespace QueroQuest.Aplication.Interfaces;

using QueroQuest.Domain.Entities;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoPorPreco();
}
