using System.IdentityModel.Tokens.Jwt;
namespace QueroQuest.API.SecurityServices.JWTProvider;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using QueroQuest.API.SecurityServices.Models;

public class AuthenticationService
{
    IConfiguration _configuration;
    //public string GenerateJwtToken(AuthenticateRequest authenticateRequest, string userId)
    public string GenerateJwtToken()
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        double jwtExpirationTime = 15;
        string secretJwtKey = "VGVzdGVzIGNvbSAuTkVUIDcsIEFTUC5ORVQgQ29yZSBlIEpXVA==";

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