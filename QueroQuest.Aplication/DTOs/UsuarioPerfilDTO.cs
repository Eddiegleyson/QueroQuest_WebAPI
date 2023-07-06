using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueroQuest.Aplication.DTOs
{
    public class UsuarioPerfilDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do Perfil")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [DefaultValue(true)]
        public bool FlAtivo { get; set; }
    }
}