namespace QueroQuest.Aplication.Services;

using System.Threading.Tasks;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Interfaces;
using AutoMapper;
using QueroQuest.Domain.Entities;

public class ProdutoService : IProdutoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProdutoService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Add(ProdutoDTO produtoDto)
    {
        try
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _unitOfWork.ProdutoRepository.Add(produto);
            _unitOfWork.Commit();

            int produtosResultDTO = produto.Id;

            return produtosResultDTO;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProdutoDTO> GetById(int? id)
    {
        try
        {
            var produto = _unitOfWork.ProdutoRepository.GetById(p => p.Id == id);
            var produtosResultDTO = _mapper.Map<ProdutoDTO>(produto);
            return produtosResultDTO;
        }
        catch
        {
            throw;
        }
    }

    public Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProdutoDTO produtoDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProdutoPorPreco()
    {
        try
        {
            var produtosEntity = await _unitOfWork.ProdutoRepository.GetProdutoPorPrecoAsync();
            var produtoResultDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
            return produtoResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}