using QueroQuest.Aplication.Interfaces;
using QueroQuest.Infra.Data.Context;

namespace QueroQuest.Infra.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ProdutoRepository _produtoRepo;
    private CategoriaRepository _categorisRepo;
    public AppDbContext _context;
    public UnitOfWork(AppDbContext contexto)
    {
        _context = contexto;
    }
    public IProdutoRepository ProdutoRepository
    {
        get
        {
            return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
        }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categorisRepo = _categorisRepo ?? new CategoriaRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
