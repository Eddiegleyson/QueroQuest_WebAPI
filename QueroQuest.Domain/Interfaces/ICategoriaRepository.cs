namespace QueroQuest.Domain.Interfaces;

using QueroQuest.Domain.Entities;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<IEnumerable<Categoria>> ObterCategoriasOrdenadoPorIdAsync();
    Task<IEnumerable<Categoria>> GetCategoriaPorProdutosAsync();
}
