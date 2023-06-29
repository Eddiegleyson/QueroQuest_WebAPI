using QueroQuest.Aplication.DTOs;

namespace QueroQuest.Aplication.Interfaces
{
    public interface ICategoriaService 
    {
        Task<IEnumerable<CategoriaDTO>> GetCategoriaPorProdutos();
        Task<IEnumerable<CategoriaDTO>> ObterCategoriasOrdenadoPorId();
        Task<IEnumerable<CategoriaDTO>> GetAll();
        
        Task<CategoriaDTO> GetById(int? id);
        Task<CategoriaDTO> Add(CategoriaDTO categoriaDto);
        Task Update(CategoriaDTO categoriaDto);
        Task Remove(int? id);
    }
}