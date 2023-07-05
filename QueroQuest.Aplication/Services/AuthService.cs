namespace QueroQuest.Aplication.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueroQuest.Aplication.Interfaces;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateJwtToken()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        double jwtExpirationTime = double.Parse(_configuration.GetConnectionString("JwtExpirationTime"));
        string secretJwtKey = _configuration.GetConnectionString("SecretJwtKey");

        byte[] key = Encoding.ASCII.GetBytes(secretJwtKey);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            // Subject = new ClaimsIdentity(new Claim[]
            // {
            //     new Claim(ClaimTypes.Name, authenticateRequest.Login),
            //     new Claim(ClaimTypes.NameIdentifier, userId),
            //     new Claim(ClaimTypes.Role, "default")
            // }),
            Expires = DateTime.UtcNow.AddMinutes(jwtExpirationTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}