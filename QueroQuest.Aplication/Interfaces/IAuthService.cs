using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueroQuest.Aplication.DTOs;

namespace QueroQuest.Aplication.Interfaces
{
    public interface IAuthService
    {
        public string GenerateJwtToken(UsuarioDTO usuarioDTO);
    }
}