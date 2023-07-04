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

    public Task<ProdutoDTO> GetById(int? id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public Task Update(ProdutoDTO produtoDto)
    {
        throw new NotImplementedException();
    }
}