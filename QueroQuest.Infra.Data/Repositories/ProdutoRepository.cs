using Microsoft.EntityFrameworkCore;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Context;

namespace QueroQuest.Infra.Data.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(ApplicationDbContext context) : base(context)
    {}
    public async Task<IEnumerable<Produto>> GetProdutoPorPrecoAsync()
    {
        return await Get().OrderBy(w => w.Preco).ToListAsync();
    }
}