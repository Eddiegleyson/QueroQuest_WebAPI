using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Context;

namespace QueroQuest.Infra.Data.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {

    }
    public IEnumerable<Produto> GetProdutoPorPreco()
    {
        return Get().OrderBy(c => c.preco).ToList();
    }
}