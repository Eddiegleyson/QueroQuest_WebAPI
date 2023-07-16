namespace QueroQuest.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using QueroQuest.Domain.Entities;
using QueroQuest.Domain.Interfaces;
using QueroQuest.Infra.Data.Context;
using QueroQuest.Infra.Data.Repository;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Usuario>> GetByLoginAsync(Usuario usuario)
    {
        return  await Get().Where(w => w.Login == usuario.Login && w.Senha == usuario.Senha).ToListAsync();
    }
}