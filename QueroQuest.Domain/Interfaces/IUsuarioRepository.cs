using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueroQuest.Domain.Entities;

namespace QueroQuest.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetByLoginAsync(Usuario usuario);
    }
}