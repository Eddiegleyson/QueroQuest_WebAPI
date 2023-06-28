namespace QueroQuest.Aplication.Interfaces;

using QueroQuest.Domain.Entities;

public interface ICategoriaRepository : IRepository<Categoria>
{
    IEnumerable<Categoria> ObterCategoriasOrdenadoPorId ();
    IEnumerable<Categoria> GetCategoriaPorProdutos();
}
