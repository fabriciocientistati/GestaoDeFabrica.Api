using FabricaGestao.Api.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FabricaGestao.Api.Extencoes;
using Microsoft.IdentityModel.Tokens;

namespace FabricaGestao.Api.Servicos;

public class TokenServicos
{
    public string GerarToken(UsuarioModelo usuario)
    {
        var manipuladorDeToken = new JwtSecurityTokenHandler();
        var chave = Encoding.ASCII.GetBytes(Configuracao.JwtChave);
        var claims = usuario.ObterClaims();
        var descricaoDoToken = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(chave),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = manipuladorDeToken.CreateToken(descricaoDoToken);
        return manipuladorDeToken.WriteToken(token);
    }
}