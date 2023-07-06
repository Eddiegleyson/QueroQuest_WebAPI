namespace QueroQuest.Aplication.Services;

using AutoMapper;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;

public class CategoriaService : ICategoriaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CategoriaDTO>> GetAll()
    {
        try
        {
            var categoriasEntity = _unitOfWork.CategoriaRepository.Get();
            var categoriaResultDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
            return categoriaResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> Add(CategoriaDTO categoriaDto)
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _unitOfWork.CategoriaRepository.Add(categoria);
            _unitOfWork.Commit();

            int categoriaId = categoria.Id;

            return categoriaId;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.StackTrace);
        }
    }

    public async Task<CategoriaDTO> GetById(int? id)
    {
        try
        {
            var categoriaEntity = _unitOfWork.CategoriaRepository.GetById(p => p.Id == id);
            var categoriaResultDTO = _mapper.Map<CategoriaDTO>(categoriaEntity);
            return categoriaResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaDTO>> GetCategoriaPorProdutos()
    {
        try
        {
            var categoriasEntity = await _unitOfWork.CategoriaRepository.GetCategoriaPorProdutosAsync();
            var categoriaResultDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
            return categoriaResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CategoriaDTO>> ObterCategoriasOrdenadoPorId()
    {
        try
        {
            var categoriasEntity = await _unitOfWork.CategoriaRepository.ObterCategoriasOrdenadoPorIdAsync();
            var categoriaResultDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
            return categoriaResultDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoriaDTO categoriaDto)
    {
        throw new NotImplementedException();
    }
}