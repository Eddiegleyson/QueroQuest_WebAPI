namespace QueroQuest.Aplication.Interfaces;

using QueroQuest.Domain.Entities;

public interface ICategoriaRepository : IRepository<Categoria>
{
    Task<IEnumerable<Categoria>> ObterCategoriasOrdenadoPorIdAsync();
    Task<IEnumerable<Categoria>> GetCategoriaPorProdutosAsync();
}
