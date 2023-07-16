namespace QueroQuest.Aplication.DTOs;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Senha { get; set; }
    public string Email { get; set; }
    public bool FlAtivo { get; set; }
    public int UsuarioPerfilId { get; set; }
}
