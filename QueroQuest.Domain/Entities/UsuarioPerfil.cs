using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueroQuest.Domain.Entities
{
    public class UsuarioPerfil : Entity
    {
        public string Nome { get; set; }
        public bool FlAtivo { get; set; }   

        public ICollection<Usuario>? Usuarios {get; set;} 

    }
}