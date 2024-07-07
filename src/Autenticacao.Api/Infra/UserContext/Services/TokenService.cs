using Autenticacao.Api.CrossCutting.Configuration;
using Autenticacao.Api.Domain.UserContext.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Autenticacao.Api.Infra.UserContext.Services;
public class TokenService
{
    private readonly SecretSettings _settings;
    public TokenService(IOptions<SecretSettings> configuration) => _settings = configuration.Value;
    public string GenerateToken (UserModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim (ClaimTypes.Name, user.Nome),
                new Claim (ClaimTypes.Role, user.Role)
            }),              
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
