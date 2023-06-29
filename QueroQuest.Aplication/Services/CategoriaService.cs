using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using QueroQuest.Aplication.DTOs;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;

namespace QueroQuest.Aplication.Services
{
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
                var categoriasEntity =  _unitOfWork.CategoriaRepository.Get();  
                var categoriaResultDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
                return categoriaResultDTO;
            }
            catch (Exception ex)
            {
                 throw;
            }
        }

        public async Task<int> Add(CategoriaDTO categoriaDto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(categoriaDto);
                _unitOfWork.CategoriaRepository.Add(categoria);
                _unitOfWork.Commit();

                int categoriaId = categoria.CategoriaId;

                return categoriaId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            try
            {
                var categoriaEntity    = _unitOfWork.CategoriaRepository.GetById(p => p.CategoriaId == id);
                var categoriaResultDTO = _mapper.Map<CategoriaDTO>(categoriaEntity);
                return categoriaResultDTO;
            }
            catch (Exception ex)
            {
                 throw;
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
                throw;
            }
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategoriasOrdenadoPorId()
        {
            try
            {
                var categoriasEntity   = await _unitOfWork.CategoriaRepository.ObterCategoriasOrdenadoPorIdAsync();
                var categoriaResultDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
                return categoriaResultDTO;
            }
            catch (Exception ex)
            {
                 throw;
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
}