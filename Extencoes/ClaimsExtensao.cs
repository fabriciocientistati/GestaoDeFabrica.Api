using System.Security.Claims;
using FabricaGestao.Api.Modelos;

namespace FabricaGestao.Api.Extencoes;

public static class ClaimsExtensao
{
    public static IEnumerable<Claim> ObterClaims(this UsuarioModelo usuario)
    {
        var resultado = new List<Claim>
        {
            new(ClaimTypes.Name, value: usuario.UsuLogin)
        };

        return resultado;
    }
}