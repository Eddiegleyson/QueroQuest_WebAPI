using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueroQuest.Aplication.DTOs;

namespace QueroQuest.Aplication.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetByLogin(UsuarioDTO usuarioDto);
        Task <int> Add(UsuarioDTO usuarioDto);
        Task Update(UsuarioDTO usuarioDto);
    }
}