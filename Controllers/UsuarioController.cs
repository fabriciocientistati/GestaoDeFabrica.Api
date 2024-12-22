using FabricaGestao.Api.Dados.Contexto;
using FabricaGestao.Api.Extencoes;
using FabricaGestao.Api.Modelos;
using FabricaGestao.Api.ViewModelos.Respostas;
using FabricaGestao.Api.ViewModelos.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity3.Password;

namespace FabricaGestao.Api.Controllers;

[Authorize]
[ApiController]
public class UsuarioController(ContextoDados contexto) : ControllerBase
{
    [HttpGet]
    [Route("v1/usuarios")]
    public async Task<IActionResult> BuscarTodosUsuarios()
    {
        try
        {
            var usuarios = await contexto.TbUsuarios
                .AsNoTracking()
                .ToListAsync();

            return usuarios.Any()
                ? Ok(new RespostaViewModelo<List<UsuarioModelo>>(usuarios))
                : NotFound(new RespostaViewModelo<UsuarioModelo>("Não foi possível encontrar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }

    [HttpPost]
    [Route("v1/usuarios")]
    public async Task<IActionResult> AdicionarUsuario(EditorUsuarioViewModelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<UsuarioModelo>(ModelState.ObterEstadoDeErros()));

        var usuario = new UsuarioModelo
        {
            UsuLogin = modelo.UsuLogin,
            UsuNome = modelo.UsuNome,
            UsuEmail = modelo.UsuEmail,
            UsuSenha = modelo.UsuSenha,
            Perfil = modelo.Perfil,
            UsuIncPor = 1
        };
        
        var senha = PasswordGenerator.Generate(25, includeSpecialChars: true, upperCase: false);
        usuario.UsuSenha = PasswordHasher.Hash(senha);
        
        try
        {
            await contexto.TbUsuarios.AddAsync(usuario);
            await contexto.SaveChangesAsync();

            return Created($"v1/usuarios/{usuario.UsuId}", new RespostaViewModelo<UsuarioModelo>(usuario));
        }
        catch(DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Não foi possível adicionar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }

    [HttpPut]
    [Route("v1/usuarios/{id:int}")]
    public async Task<IActionResult> AtualizarUsuarios(int id, EditorUsuarioViewModelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RespostaViewModelo<UsuarioModelo>(ModelState.ObterEstadoDeErros()));
        
        try
        {
            var usuario = await contexto.TbUsuarios.FirstOrDefaultAsync(x => x.UsuId == id);

            if (usuario == null)
                return NotFound(new RespostaViewModelo<UsuarioModelo>("Não foi possível encontrar"));

            usuario.UsuNome = modelo.UsuNome;
            usuario.UsuLogin = modelo.UsuLogin;
            usuario.UsuEmail = modelo.UsuEmail;
            usuario.Perfil = modelo.Perfil;
            usuario.UsuAltPor = 1;
            
            contexto.TbUsuarios.Update(usuario);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<UsuarioModelo>(usuario));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Não foi possível atualizar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }

    [HttpDelete]
    [Route("v1/usuarios/{id:int}")]
    public async Task<IActionResult> ApagarUsuario(int id)
    {
        try
        {
            var usuario = await contexto.TbUsuarios.FirstOrDefaultAsync(x => x.UsuId == id);

            if (usuario == null)
                return NotFound(new RespostaViewModelo<UsuarioModelo>("Não foi possível encontrar"));

            contexto.TbUsuarios.Remove(usuario);
            await contexto.SaveChangesAsync();

            return Ok(new RespostaViewModelo<UsuarioModelo>(usuario));
        }
        catch(DbUpdateException)
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Não foi possível apagar"));
        }
        catch
        {
            return StatusCode(500, new RespostaViewModelo<UsuarioModelo>("Falha interna no servidor"));
        }
    }
}