namespace QueroQuest.Domain.Interfaces;
using System.Linq.Expressions;
public interface IRepository<T>
{
    IQueryable<T> Get();
    T GetById(Expression<Func<T, bool>> Predicate);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
