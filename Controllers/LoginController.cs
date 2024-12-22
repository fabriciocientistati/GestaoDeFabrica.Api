using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.Servicos;
using FabricaGestao.Api.ViewModelos.Login;
using FabricaGestao.Api.ViewModelos.Respostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity3.Password;

namespace FabricaGestao.Api.Controllers;

[ApiController]

public class LoginController(ContextoDados contexto) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    [Route("v1/login")]
    public async Task<IActionResult> Login(
        LoginViewModelo modelo,
        TokenServicos tokenServicos)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<UsuarioModelo>(ModelState.ObterEstadoDeErros()));

        var usuario = await contexto.TbUsuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UsuLogin == modelo.UsuLogin);

        if (usuario == null)
            return StatusCode(401, new RespostaViewModelo<UsuarioModelo>("Usuário ou senha inválidos"));

        if (!PasswordHasher.Verify(usuario.UsuSenha, modelo.UsuSenha))
            return StatusCode(401, new RespostaViewModelo<UsuarioModelo>("Usuário ou senha inválidos"));
        try
        {
            var token = tokenServicos.GerarToken(usuario);
            return Ok(new RespostaViewModelo<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<string>("Falha interna no servidor"));
        }
    }
}