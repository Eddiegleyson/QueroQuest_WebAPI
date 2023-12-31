namespace QueroQuest.Aplication.Interfaces;

using QueroQuest.Aplication.DTOs;
public interface IProdutoService
{
    Task<IEnumerable<ProdutoDTO>> GetProdutoPorPreco();
    Task<ProdutoDTO> GetById(int? id);
    Task<int> Add(ProdutoDTO produtoDto);
    Task Update(ProdutoDTO produtoDto);
    Task Remove(int? id);
}