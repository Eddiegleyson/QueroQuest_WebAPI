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

    public IEnumerable<Categoria> GetCategoriaPorProdutos()
    {
        return Get().Include(w => w.Produtos);
    }

    public IEnumerable<Categoria> ObterCategoriasOrdenadoPorId()
    {
        return Get().OrderBy(w => w.CategoriaId).ToList();
    }
}