namespace QueroQuest.Aplication.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;
using System.Security.Claims;

public class AuthService : IAuthService
{
    private IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJwtToken(UsuarioDTO usuarioDTO)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        double jwtExpirationTime = double.Parse(_configuration.GetSection("TokenConfigurations").GetSection("JwtExpirationTime").Value);
        string secretJwtKey = _configuration.GetSection("TokenConfigurations").GetSection("SecretJwtKey").Value;

        byte[] key = Encoding.ASCII.GetBytes(secretJwtKey);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuarioDTO.Nome),
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.Nome),
                new Claim(ClaimTypes.Role, usuarioDTO.UsuarioPerfilId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(jwtExpirationTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}