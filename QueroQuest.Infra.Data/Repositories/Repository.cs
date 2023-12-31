using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Context;

namespace QueroQuest.Infra.Data.Repository;

    public class Repository<T> : IRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Get()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public T GetById(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.Set<T>().Update(entity);
    }
}

