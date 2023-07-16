namespace QueroQuest.Aplication.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueroQuest.Aplication.Interfaces;
using QueroQuest.Aplication.DTOs;
using System.Security.Claims;
using System.Security.Cryptography;

public class AuthService : IAuthService
{
    private IConfiguration _configuration;
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Decrypt(string textValue)
    {
        try
        {
            string textToDecrypt = textValue;
            string ToReturn = "";
            string publickey = "BlY9+e==";
            string secretkey = "==qcB0UB";
            byte[] privatekeyByte = { };
            privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeybyte = { };
            publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
            inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                ToReturn = encoding.GetString(ms.ToArray());
            }
            return ToReturn;
        }
        catch (Exception ae)
        {
            throw new Exception(ae.Message, ae.InnerException);
        }
    }

    public string Encrypt(string textValue)
    {
        try
        {
            string textToEncrypt = textValue;
            string ToReturn = "";
            // string publickey = "12345678";
            // string secretkey = "87654321";

            string publickey = "BlY9+e==";
            string secretkey = "==qcB0UB";

            byte[] secretkeyByte = { };
            secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeybyte = { };
            publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                ToReturn = Convert.ToBase64String(ms.ToArray());
            }
            return ToReturn;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
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
                new Claim(ClaimTypes.Name, usuarioDTO.Login),
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.Login),
                new Claim(ClaimTypes.Role, usuarioDTO.UsuarioPerfilId.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(jwtExpirationTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}