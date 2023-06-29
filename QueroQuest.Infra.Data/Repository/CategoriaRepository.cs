using Microsoft.EntityFrameworkCore;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;
using QueroQuest.Infra.Data.Context;

namespace QueroQuest.Infra.Data.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Categoria>> GetCategoriaPorProdutosAsync()
    {
        return await Get().Include(w => w.Produtos).ToListAsync();
    }

    public async Task<IEnumerable<Categoria>> ObterCategoriasOrdenadoPorIdAsync()
    {
        return await Get().OrderBy(w => w.CategoriaId).ToListAsync();
    }
}