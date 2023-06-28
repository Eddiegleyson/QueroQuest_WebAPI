using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Entities;

namespace QueroQuest.Aplication.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Categoria> Get()
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(Expression<Func<Categoria, bool>> Predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategoriaPorProdutos()
        {
            return _unitOfWork.CategoriaRepository.GetCategoriaPorProdutos().ToList();
        }

        public IEnumerable<Categoria> ObterCategoriasOrdenadoPorId()
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}