using QueroQuest.Aplication.Interfaces;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Context;
using QueroQuest.Infra.Data.Repositories;

namespace QueroQuest.Infra.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ProdutoRepository _produtoRepo;
    private CategoriaRepository _categorisRepo;

    private UsuarioRepository _usuarioRepo;
    public ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext contexto)
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

    public IUsuarioRepository UsuarioRepository
    {
        get 
        {
            return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
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
