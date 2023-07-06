namespace QueroQuest.Domain.Entities
{
    public class Usuario : Entity
    {
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public bool FlAtivo { get; set; }
        public int UsuarioPerfilId { get; set; }
        public UsuarioPerfil? UsuarioPerfil {get; set;}
    }
}