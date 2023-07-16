namespace QueroQuest.Aplication.Interfaces;

using QueroQuest.Aplication.DTOs;
public interface IAuthService
{
    public string GenerateJwtToken(UsuarioDTO usuarioDTO);
    public string Decrypt(string textValue);
    string Encrypt(string textValue);
}